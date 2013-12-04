using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class Kysely : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //Event handleri dropdownlistille, muuttaa näkyvillä olevien text boxejen määrää aina kun arvo muutetaan.
    protected void maara_SelectedIndexChanged(object sender, EventArgs e)
    {
        int maar = Convert.ToInt32(maara.SelectedValue);

        vaiht1.Visible = false;
        vaiht2.Visible = false;
        vaiht3.Visible = false;
        vaiht4.Visible = false;
        vaiht5.Visible = false;

        //if (maar > 2)
        //{


        for (int i = 0; i < maar; i++)
        {
            if (i == 0)
            {
                vaiht1.Visible = true;
            }
            else if (i == 1)
            {
                vaiht2.Visible = true;
            }

            else if (i == 2)
            {
                vaiht3.Visible = true;
            }

            else if (i == 3)
            {
                vaiht4.Visible = true;
            }

            else if (i == 4)
            {
                vaiht5.Visible = true;
            }
        }
        // }
    }

    //Handleri lisäys napille. Lisää kysymyksen XML tiedostoon.
    protected void submit_Click(object sender, EventArgs e)
    {

        
        //pathi xml tiedostolle
        string filename = Server.MapPath("~/App_Data/kysymykset.xml");

        XmlDocument doc = new XmlDocument();

        //ladataan xml annetusta  pathista
        doc.Load(filename);

        //luodaan uusi kysymys node, johon sen jälkeen appendataan useaan otteeseen tietoa
        XmlNode node = doc.CreateNode(XmlNodeType.Element, "kysymys", null);

        XmlNode nodeTxt = doc.CreateElement("text");

        nodeTxt.InnerText = kysymys.Text;

        node.AppendChild(nodeTxt);


        XmlNode nodeMaar = doc.CreateElement("maara");
        nodeMaar.InnerText = maara.SelectedValue;
        node.AppendChild(nodeMaar);

        int maar = Convert.ToInt32(maara.SelectedValue);

        XmlNode kysnode;
        XmlNode nodeKylla;

        for (int i = 1; i - 1 < maar; i++)
        {
            kysnode = doc.CreateNode(XmlNodeType.Element, "vaihtoehto", null);
            nodeKylla = doc.CreateElement("vaiht");

            if (i == 1)
            {
                nodeKylla.InnerText = vaiht1.Text;
                kysnode.AppendChild(nodeKylla);

            }
            else if (i == 2)
            {
                nodeKylla.InnerText = vaiht2.Text;
                kysnode.AppendChild(nodeKylla);
            }
            else if (i == 3)
            {
                nodeKylla.InnerText = vaiht3.Text;
                kysnode.AppendChild(nodeKylla);
            }
            else if (i == 4)
            {
                nodeKylla.InnerText = vaiht4.Text;
                kysnode.AppendChild(nodeKylla);
            }

            else if (i == 5)
            {
                nodeKylla.InnerText = vaiht5.Text;
                kysnode.AppendChild(nodeKylla);
            }

            nodeKylla = doc.CreateElement("vastattu");
            nodeKylla.InnerText = "0";
            kysnode.AppendChild(nodeKylla);

            node.AppendChild(kysnode);
        }

        nodeKylla = doc.CreateElement("vastauksia");
        nodeKylla.InnerText = "0";
        node.AppendChild(nodeKylla);


        System.DateTime today = System.DateTime.Now;
        System.TimeSpan duration = new System.TimeSpan(0, Convert.ToInt32(aika.SelectedValue), 0);
        System.DateTime answer = today.Add(duration);


        nodeKylla = doc.CreateElement("aika");
        nodeKylla.InnerText = answer.ToString(); ;
        node.AppendChild(nodeKylla);

        doc.DocumentElement.AppendChild(node);

        doc.Save(filename);

        lis.Text = "Uusi kysely lisätty";

    }

    //handleri buttonille, palauttaa vastauslomakkeeseen.
    protected void Vastaamaan_Click(object sender, EventArgs e)
    {
        Server.Transfer("~/Vastaus.aspx");

    }




}