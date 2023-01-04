using Microsoft.Maui.Controls;
using System.ComponentModel;


namespace ListViewMaui
{
    #region ListViewContactInfo
    public class ListViewContactInfo : INotifyPropertyChanged
    {
        #region Fields

        private string? contactName;
        private string? contactNo;
        private ImageSource? image;

        #endregion

        #region Constructor

        public ListViewContactInfo()
        {

        }

        #endregion

        #region Public Properties

        public string? ContactName
        {
            get { return this.contactName; }
            set
            {
                this.contactName = value;
                RaisePropertyChanged("ContactName");
            }
        }

        public string? ContactNumber
        {
            get { return contactNo; }
            set
            {
                this.contactNo = value;
                RaisePropertyChanged("ContactNumber");
            }
        }

        public ImageSource? ContactImage
        {
            get { return this.image; }
            set
            {
                if (value != null)
                {
                    this.image = value;
                    this.RaisePropertyChanged("ContactImage");
                }
            }
        }

        #endregion

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler? PropertyChanged;

        private void RaisePropertyChanged(String name)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
    #endregion
}