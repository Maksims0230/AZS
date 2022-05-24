using AzsApp.RequestHelper;
using AzsApp.WF.Models;

namespace AzsApp.WF
{
    using Helper1 = RequestHelper<StationBase>;
    using Helper2 = RequestHelper<List<StationFuel>>;

    public partial class StationSearchForm : Form
    {
        public StationSearchForm() => InitializeComponent();

        private async void SearchBtn_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(StationIdMTB.Text, out int id) || id < 1)
                return;
            var result = await Helper1.GetAsync($"http://127.0.0.1:8080/getStationInfo?id={id}");
            MessageBox.Show(result is { } ? $"Id: {result.Station_ID}\r\nAddress: {result.Address}" : "Failed");
        }

        private async void Search2Btn_Click(object sender, EventArgs e)
        {
            var result = await Helper2.GetAsync($"http://127.0.0.1:8080/stations?fuel={FuelTypeMTB.Text}");
            MessageBox.Show(
                result is { Count: > 0 } ?
                $"Count: {result.Count}\r\n\r\n    First Station:\r\n\tId: {result[0].Station_ID}\r\n\tAddress: {result[0].Address}\r\n\tFuel Price: {result[0].Price}\r\n\r\n..."
                : $"Count: {result?.Count ?? 0}\r\n\r\nFailed or not found."
                );
        }
    }
}
