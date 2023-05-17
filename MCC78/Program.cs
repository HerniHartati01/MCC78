

using System.Data.SqlClient;
using System.Data;
using Microsoft.VisualBasic;
using System.Xml.Linq;
using System.Dynamic;
using System.Security;
using System.Runtime.CompilerServices;
using MCC78.View;
using MCC78.Controller;
using MCC78.Model;

public class Program
{
  

    public static void Main()
    {
        //Panggil method menu --> tampilan
        
        MenuView menuView = new MenuView();
        menuView.MenuTampilan();

    }


    
}