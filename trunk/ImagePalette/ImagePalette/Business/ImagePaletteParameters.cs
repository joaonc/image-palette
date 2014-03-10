using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
            if (object.Equals(storage, value))
                return false;

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

        private List<string> fileNames;
        /// <summary>
        /// The input files.
        /// This list may contain directories, so in order to get the full list of files, use the GetExpandedFileNames() method.
        /// Note that if the list's contents are changed, the OnPropertyChanged event is not fired.
        /// </summary>
        public List<string> FileNames
        {
            get { return fileNames; }
            set { SetProperty<List<string>>(ref fileNames, value); }
        }

        private string fileNameReference;
        public string FileNameReference
        {
            get { return fileNameReference; }
            set { SetProperty<string>(ref fileNameReference, value); }
        }

        private string fileNameOutput;
        public string FileNameOutput
        {
            get { return fileNameOutput; }
            set { SetProperty<string>(ref fileNameOutput, value); }
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

        private double thresholdIndexed;
        public double ThresholdIndexed
        {
            get { return thresholdIndexed; }
            set { SetProperty<double>(ref thresholdIndexed, value); }
        }

        private int thresholdMatched;
        public int ThresholdMatched
        {
            get { return thresholdMatched; }
            set { SetProperty<int>(ref thresholdMatched, value); }
        }

        private bool applyThresholdDistance;
        public bool ApplyThresholdDistance
        {
            get { return applyThresholdDistance; }
            set { SetProperty<bool>(ref applyThresholdDistance, value); }
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

        private bool exploreMode;
        /// <summary>
        /// This mode makes the algorithms calculate every value regardless of thresholds applied.
        /// The UI then takes care of filtering to apply the threshold.
        /// Makes it quicker for the UI to refresh when thresholds are switched between apply/not apply,
        /// which makes exploration with UI faster.
        /// This option should be turned off for final processing (especially batch operations) as it's slower.
        /// </summary>
        public bool ExploreMode
        {
            get { return exploreMode; }
            set { SetProperty<bool>(ref exploreMode, value); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the full list of filenames with possible directories in the property FileNames expanded.
        /// </summary>
        /// <returns></returns>
        public List<string> GetExpandedFileNames()
        {
            List<string> expandedFileNames = new List<string>();

            if (FileNames != null)
            {
                foreach (string fileName in FileNames)
                {
                    if (!string.IsNullOrWhiteSpace(fileName))
                    {
                        if (Directory.Exists(fileName))
                        {
                            // Directory
                            expandedFileNames.AddRange(Directory.GetFiles(fileName));
                        }
                        else if (File.Exists(fileName))
                        {
                            // File
                            expandedFileNames.Add(fileName);
                        }
                        // else it's neither a file nor a directory, doesn't exist
                    }
                }
            }

            return expandedFileNames;
        }

        #endregion
    }
}
