using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RasporedRC.Model
{
    public class TestOutput : INotifyPropertyChanged
    {
        private string text;
        private string toolTipText;
        private int heightOfElem;
        private Brush bgColor;

        public event PropertyChangedEventHandler PropertyChanged;

        public TestOutput(string text, int heightOfElem)
        {
            this.text = text;
            this.heightOfElem = heightOfElem;
            this.ToolTipText = "Just a tooltip text";
            if (text.Equals(""))
            {
                bgColor = new SolidColorBrush(Colors.Gray);
            }else
            {
                bgColor = new SolidColorBrush(Colors.LightGoldenrodYellow);
            }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public string ToolTipText
        {
            get { return toolTipText; }
            set { toolTipText = value; }
        }

        public int HeightOfElem
        {
            get { return heightOfElem; }
            set { heightOfElem = value; }
        }

        public Brush BgColor
        {
            get { return bgColor; }
            set { bgColor = value; }
        }
    }
}
