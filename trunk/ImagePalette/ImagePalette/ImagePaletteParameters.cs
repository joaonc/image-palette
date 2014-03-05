using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ImagePalette
{
    /// <summary>
    /// Application parameters.
    /// XML serializable.
    /// 
    /// INotifyPropertyChanged implementation mechanism from link below
    /// http://danrigby.com/2012/04/01/inotifypropertychanged-the-net-4-5-way-revisited/
    /// </summary>
    public class ImagePaletteParameters : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged implementation

        /// <summary>
        /// Property changed notification. Good for UI hookup (and other uses).
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Checks if a property already matches a desired value.  Sets the property and
        /// notifies listeners only when necessary.
        /// 
        /// Type of the property.
        /// Reference to a property with both getter and setter.
        /// Desired value for the property.
        /// Name of the property used to notify listeners.  This
        /// value is optional and can be provided automatically when invoked from compilers that
        /// support CallerMemberName.
        /// True if the value was changed, false if the existing value matched the
        /// desired value.        /// </summary>
        /// <param name="storage"></param>
        /// <param name="value"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
        {
            if (object.Equals(storage, value)) return false;

            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Properties

        private string fileName;
        public string FileName
        {
            get { return fileName; }
            set { SetProperty<string>(ref fileName, value); }
        }

        private string fileNameReference; 
        public string FileNameReference
        {
            get { return fileNameReference; }
            set { SetProperty<string>(ref fileNameReference, value); }
        }

        private int coverage;
        public int Coverage
        {
            get { return coverage; }
            set { SetProperty<int>(ref coverage, value); }
        }

        private int distance;
        public int Distance
        {
            get { return distance; }
            set { SetProperty<int>(ref distance, value); }
        }

        private int thresholdIndexed;
        public int ThresholdIndexed
        {
            get { return thresholdIndexed; }
            set { SetProperty<int>(ref thresholdIndexed, value); }
        }

        private int thresholdMatched;
        public int ThresholdMatched
        {
            get { return thresholdMatched; }
            set { SetProperty<int>(ref thresholdMatched, value); }
        }

        private bool applyThresholdIndexed;
        public bool ApplyThresholdIndexed
        {
            get { return applyThresholdIndexed; }
            set { SetProperty<bool>(ref applyThresholdIndexed, value); }
        }

        private bool applyThresholdMatched;
        public bool ApplyThresholdMatched
        {
            get { return applyThresholdMatched; }
            set { SetProperty<bool>(ref applyThresholdMatched, value); }
        }

        #endregion
    }
}
