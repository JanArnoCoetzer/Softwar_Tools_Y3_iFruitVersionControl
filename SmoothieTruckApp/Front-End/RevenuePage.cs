using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using SmoothieTruckApp.Models;
using SmoothieTruckApp.Repositories;
using SmoothieTruckApp.Services;

namespace SmoothieTruckApp.Front_End
{
    public partial class RevenuePage : UserControl
    {
        private static readonly Color Purple = Color.FromArgb(124, 58, 237);
        private static readonly Color Grey = Color.FromArgb(120, 124, 145);
        private static readonly Color[] BarColors =
        {
            Color.FromArgb(124, 58, 237),   // purple
            Color.FromArgb(6, 182, 212),    // cyan
            Color.FromArgb(245, 158, 11),   // amber
            Color.FromArgb(249, 115, 22),   // orange
        };

        private bool showingWeek = true;

        public event EventHandler<bool>? PeriodChanged;

        public RevenuePage()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            btnWeek.Click += (s, e) => SetPeriod(true);
            btnMonth.Click += (s, e) => SetPeriod(false);
            flowBlends.ClientSizeChanged += (s, e) => FitRows();

            lblRevenueSub.Text = $"Sales performance for {DateTime.Now:dddd, MMMM d}";

            statTotalSales.SetIcon("€", Color.FromArgb(237, 233, 254), Color.FromArgb(124, 58, 237));
            statTotalSales.SetHighlight(true);
            statAvgOrder.SetIcon("#", Color.FromArgb(207, 250, 254), Color.FromArgb(8, 145, 178));
            statTopBlend.SetIcon("★", Color.FromArgb(254, 243, 226), Color.FromArgb(217, 119, 6));

            //reload every time the page is opened so new completed orders show
            ParentChanged += (s, e) =>
            {
                if (Parent != null) LoadRevenue();
            };

            ApplyPeriodStyle();
        }

        public void LoadRevenue()
        {
            List<Order> orders;

            try
            {
                orders = OrderRepository.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not load orders:\n{ex.Message}", "Load failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime today = DateTime.Today;
            DateTime tomorrow = today.AddDays(1);

            //today is compared with the same day last week
            decimal todaySales = RevenueService.TotalSales(orders, today, tomorrow);
            decimal lastWeekSales = RevenueService.TotalSales(orders, today.AddDays(-7), today.AddDays(-6));
            decimal? change = RevenueService.PercentChange(todaySales, lastWeekSales);

            SetTotalSales(Euro(todaySales),
                change.HasValue ? $"{(change.Value >= 0 ? "+" : "")}{change.Value}%" : "",
                $"from last {today:dddd}");

            int todayCount = RevenueService.Sales(orders, today, tomorrow).Count;
            SetAverageOrder(Euro(RevenueService.AverageOrder(orders, today, tomorrow)),
                $"{todayCount} completed orders");

            DateTime start = showingWeek ? RevenueService.WeekStart(today) : RevenueService.MonthStart(today);
            int days = showingWeek ? 7 : DateTime.DaysInMonth(today.Year, today.Month);
            DateTime end = start.AddDays(days);

            var top = RevenueService.TopBlends(orders, start, end, 4);

            if (top.Count > 0)
                SetTopBlend(top[0].Name, $"{top[0].Units} sold · {Euro(top[0].Revenue)} revenue");
            else
                SetTopBlend("None yet", showingWeek ? "No sales this week" : "No sales this month");

            SetTopBlends(top.ToArray());

            var daily = RevenueService.DailyTotals(orders, start, days);

            SetTrend(daily.Select(d => showingWeek ? d.Day.ToString("ddd", CultureInfo.InvariantCulture) : d.Day.Day.ToString()).ToArray(),
                daily.Select(d => (double)d.Total).ToArray(),
                Euro(daily.Sum(d => d.Total), 0));
        }

        private static string Euro(decimal value, int decimals = 2)
        {
            return "€" + value.ToString("N" + decimals, CultureInfo.InvariantCulture);
        }

        public void SetTotalSales(string value, string delta, string subText)
        {
            statTotalSales.SetStat("Total Daily Sales", value, subText, delta);
        }


        public void SetAverageOrder(string value, string subText)
        {
            statAvgOrder.SetStat("Average Order Value", value, subText);
        }

 
        public void SetTopBlend(string name, string subText)
        {
            statTopBlend.SetStat("Top Selling Blend", name, subText);
        }

        public void SetTrend(string[] labels, double[] values, string totalText)
        {
            lineTrend.SetData(labels, values);
            lblWeekTotal.Text = totalText;
        }

        public void SetTopBlends(params (string Name, int Units, decimal Revenue)[] blends)
        {
            flowBlends.SuspendLayout();

            while (flowBlends.Controls.Count > 0)
            {
                Control c = flowBlends.Controls[0];
                flowBlends.Controls.RemoveAt(0);
                c.Dispose();
            }

            int maxUnits = 0;
            foreach (var b in blends) maxUnits = Math.Max(maxUnits, b.Units);

            for (int i = 0; i < blends.Length; i++)
            {
                var row = new BlendRankRow();
                row.Margin = new Padding(0);
                double percent = maxUnits > 0 ? blends[i].Units * 100.0 / maxUnits : 0;
                row.SetBlend(i + 1, blends[i].Name, blends[i].Units, blends[i].Revenue,
                             percent, BarColors[i % BarColors.Length]);
                flowBlends.Controls.Add(row);
            }

            flowBlends.ResumeLayout(true);
            FitRows();
        }


        private void SetPeriod(bool week)
        {
            if (week == showingWeek) return;
            showingWeek = week;
            ApplyPeriodStyle();
            LoadRevenue();
            PeriodChanged?.Invoke(this, week);
        }

        private void ApplyPeriodStyle()
        {
            pnlWeek.FillColor = showingWeek ? Purple : Color.White;
            btnWeek.ForeColor = showingWeek ? Color.White : Grey;
            pnlMonth.FillColor = showingWeek ? Color.White : Purple;
            btnMonth.ForeColor = showingWeek ? Grey : Color.White;
            pnlWeek.Invalidate();
            pnlMonth.Invalidate();

            lblWeekCaption.Text = showingWeek ? "WEEK TOTAL" : "MONTH TOTAL";
            lblTrendSub.Text = showingWeek ? "Daily sales this week" : "Daily sales this month";
        }

        private void FitRows()
        {
            foreach (Control c in flowBlends.Controls)
                c.Width = flowBlends.ClientSize.Width - c.Margin.Horizontal;
        }
    }
}