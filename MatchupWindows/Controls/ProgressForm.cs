using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchupWindows.Controls
{
    public partial class ProgressForm : Form
    {
        public string CurrentLeague
        {
            get
            {
                return CurrentLeagueLabel.Text;
            }
            set
            {
                CurrentLeagueLabel.Text = value;
            }
        }

        public int ProgressValue
        {
            get
            {
                return LoadingBar.Value;
            }
            set
            {
                LoadingBar.Value = value;

            }
        }


        public ProgressForm()
        {
            InitializeComponent();
        }
    }
}
