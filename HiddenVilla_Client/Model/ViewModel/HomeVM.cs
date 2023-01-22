namespace HiddenVilla_Client.Model.ViewModel
{
    //view model pro index.html
    public class HomeVM
    {
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; }
        public int NumberOfNights { get; set; } = 1;
    }
}
