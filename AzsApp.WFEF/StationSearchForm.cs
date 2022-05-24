using AzsApp.WFEF.Context;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace AzsApp.WFEF
{
    public partial class StationSearchForm : Form
    {
        private readonly AzsDbContext _context = new();

        public StationSearchForm() => InitializeComponent();

        private async void SearchBtn_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(StationIdMTB.Text, out int id) || id < 1)
                return;
            var result = await _context.Stations.FindAsync(id);
            MessageBox.Show(result is { } ? $"Id: {result.Station_ID}\r\nAddress: {result.Address}" : "Failed");
        }

        private async void Search2Btn_Click(object sender, EventArgs e)
        {
            var result = await _context.Stations.Include(station => station.Data)
                .Where(station => station.Data.Any(data =>
                    data.Name == (FuelTypeMTB.Text.ToUpper() == "DT" ? "Disel Fuel" : FuelTypeMTB.Text))
                )
                .Select(station =>
                new
                {
                    station.Station_ID,
                    station.Address,
                    station.Data.First(data => data.Name == FuelTypeMTB.Text).Price
                }).ToListAsync();

            MessageBox.Show(
                result is { Count: > 0 } ?
                $"Count: {result.Count}\r\n\r\n    First Station:\r\n\tId: {result[0].Station_ID}\r\n\tAddress: {result[0].Address}\r\n\tFuel Price: {result[0].Price}\r\n\r\n..."
                : $"Count: {result?.Count ?? 0}\r\n\r\nFailed or not found."
                );
        }
    }
}
