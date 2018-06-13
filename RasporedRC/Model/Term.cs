using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RasporedRC.Model
{
    public class Term : INotifyPropertyChanged
    {
        private string subjectId;
        private string courseId;
        private string subjectName;
        private string courseName;
        private string displayText;
        private string toolTipText;
        private int heightOfElem;
        private Brush bgColor;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public Term(string courseId,string courseName,string subjectId,string subjectName)
        {
            this.subjectId = subjectId;
            this.subjectName = subjectName;
            this.courseId = courseId;
            this.courseName = courseName;
            displayText = "";

            updateDisplay();
            updateTooltip();

            if (subjectId.Equals(""))
            {
                BgColor = new SolidColorBrush(Colors.LightGray);
                HeightOfElem = 10;
            }
            else
            {
                BgColor = new SolidColorBrush(Colors.White);
                HeightOfElem = 32;
            }

        }

        public string SubjectId
        {
            get { return subjectId; }
            set { subjectId = value; }
        }
        public string CourseId
        {
            get { return courseId; }
            set { courseId = value; }
        }
        public string SubjectName
        {
            get { return subjectName; }
            set { subjectName = value; }
        }
        public string CourseName
        {
            get { return courseName; }
            set { courseName = value; }
        }
        public Brush BgColor
        {
            get { return bgColor; }
            set
            {
                bgColor = value;
                OnPropertyChanged("BgColor");
            }
            
        }
        public int HeightOfElem
        {
            get { return heightOfElem; }
            set
            {
                heightOfElem = value;
                OnPropertyChanged("HeightOfElem");
            }
        }
        public string ToolTipText
        {
            get { return toolTipText; }
            set
            {
                toolTipText = value;
                OnPropertyChanged("ToolTipText");
            }
        }
        public string DisplayText
        {
            get { return displayText; }
            set
            {
                displayText = value;
                OnPropertyChanged("DisplayText");
            }
        }

        public void update()
        {
            this.updateDisplay();
            this.updateTooltip();
        }

        private void updateDisplay()
        {
            if(courseId == "")
            {
                DisplayText = "";
                return;
            }
            if (courseId.Length > 14)
            {
                DisplayText = "S: " + courseId.Substring(0, 12) + "..\n";
            }
            else
            {
                DisplayText += "S: " + courseId + "\n";
            }
            if (subjectId.Length > 14)
            {
                DisplayText += "P: " + SubjectId.Substring(0, 12) + "..";
            }
            else
            {
                DisplayText += "P: " + SubjectId;
            }
        }

        private void updateTooltip()
        {
            if (courseId == "")
            {
                this.ToolTipText = "15 minuta";
                return;
            }
            else
            {
                this.toolTipText = "Smer: " + courseName + "\nPredmet: " + subjectName;
            }
        }
    }
}
