using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizCreator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            PresenterInterface presenter = new Presenter();
            ViewInterface view = new Form1(presenter);
            FileModelInterface fileModel = new FileModel();

            presenter.SetUp(view, fileModel);

            Application.Run((Form)view);
        }
    }
}
