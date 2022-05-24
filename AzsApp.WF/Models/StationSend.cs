namespace AzsApp.WF.Models
{
    internal class StationSend : StationBase
    {
        public IEnumerable<Data> Data { get; set; } = null!;
    }
}