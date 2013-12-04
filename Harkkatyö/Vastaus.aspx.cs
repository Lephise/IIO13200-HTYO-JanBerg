using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using System.Xml;

public partial class Vastaus : System.Web.UI.Page
{
  
    XMLhandler xml;
    int maara;
    
    

    protected void Page_Load(object sender, EventArgs e)
    {
        xml = new XMLhandler(Server.MapPath("~/App_Data/kysymykset.xml"));

        if (!IsPostBack)
        {
            int cur = 1;
            List<string> vastattu = new List<string>();
            Session["vastattu"] = vastattu;
            Session["current"] = cur;

            if (xml.checkXML() == true)
            {
                var kysymykset = xml.getOptions(cur);

                label.Text = xml.getQuestion(cur);


                for (int i = 0; i < kysymykset.Count; i++)
                {

                    ListItem rad = new ListItem();

                    if (i == 0)
                    {
                        rad.Selected = true;
                    }

                    rad.Text = kysymykset[i];
                    rad.Value = i.ToString();

                    buttoset.Items.Add(rad);
                }


                if (xml.getTime(cur) < System.DateTime.Now)
                {
                    btn.Enabled = false;
                }
            }

            else
            {
                Response.Redirect("~/Kysely.aspx");
            }
        }


        

    }

    //lähettää vastauksen kysymykseen
    protected void btn_Click(object sender, EventArgs e)
    {

        List<string> vast = (List<string>)Session["vastattu"];
        int cur = (int)Session["current"];
        
        //tarkistaa onko buttoset kontrolli tyhjä ja tarkistaa että kysymykseen ei olla jo vastattu
        if (buttoset.Items.Count != 0 && !vast.Contains(cur.ToString()))
        {

            
            vast.Add(cur.ToString());
            Session["vastattu"] = vast;

            xml.addAnswered(cur, (buttoset.SelectedIndex + 1));
            
            var points = pie.Series.FindByName("Testing").Points;
            points.Clear();

            maara = xml.getAmount(cur);
            var kysymykset = xml.getOptions(cur);
            var vastaukset = xml.getAnswered(cur);


            for (int i = 1; i < maara + 1; i++)
            {
                if (vastaukset[i-1] != 0){

                DataPoint piste = new DataPoint();
                piste.AxisLabel = kysymykset[i - 1];
                piste.YValues[0] = vastaukset[i - 1];
                points.Add(piste);
                }


            }

            pie.Visible = true;
            btn.Enabled = false;
        

            

        }

        else
        {
            
        }


        }

      




    


    //Lataa seuraavan kysymyksen
    protected void btnNext_Click(object sender, EventArgs e)
    {
        
        int cur = (int)Session["current"];


        if (xml.checkQuestion(cur + 1))
        {

            btn.Enabled = true;

            cur++;
            Session["current"] = cur;

            var kysymykset = xml.getOptions(cur);
            


            buttoset.Items.Clear();


            for (int i = 0; i < kysymykset.Count; i++)
            {

                ListItem rad = new ListItem();

                if (i == 0)
                {
                    rad.Selected = true;
                }

                rad.Text = kysymykset[i];
                rad.Value = i.ToString();

                buttoset.Items.Add(rad);
            }

        }

        label.Text = xml.getQuestion(cur);


        if (xml.getTime(cur) < System.DateTime.Now)
        {
            btn.Enabled = false;
        }

        List<string> vast = (List<string>)Session["vastattu"];
        int curr = (int)Session["current"];

        if (vast.Contains(curr.ToString()))
        {
            btn.Enabled = false;
        }

    }


    //Lataa edellisen kysymyksen

    protected void btnPre_Click(object sender, EventArgs e)
    {


        
        int cur = (int)Session["current"];
        

        if (xml.checkQuestion(cur-1))
        {

            btn.Enabled = true;

            cur--;
            Session["current"] = cur;

            var kysymykset = xml.getOptions(cur);

            

            buttoset.Items.Clear();


            for (int i = 0; i < kysymykset.Count; i++)
            {

                ListItem rad = new ListItem();

                if (i == 0)
                {
                    rad.Selected = true;
                }

                rad.Text = kysymykset[i];
                rad.Value = i.ToString();
               
                buttoset.Items.Add(rad);
            }

            label.Text = xml.getQuestion(cur);

            if (xml.getTime(cur) < System.DateTime.Now)
            {
                btn.Enabled = false;
            }

        }

        List<string> vast = (List<string>)Session["vastattu"];
        int curr = (int)Session["current"];

        if (vast.Contains(curr.ToString()))
        {
            btn.Enabled = false;
        }
    }

    //"Linkki" kysymyksen luonti sivulle
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Kysely.aspx");
    }

    //Näyttää diagrammin kyseisestä kysymyksestä
    protected void btnShow_Click(object sender, EventArgs e)
    {

        int cur = (int)Session["current"];

        var points = pie.Series.FindByName("Testing").Points;
        points.Clear();

        maara = xml.getAmount(cur);
        var kysymykset = xml.getOptions(cur);
        var vastaukset = xml.getAnswered(cur);

        if (xml.getNumberOfAnswers(cur) != 0)
        {


            for (int i = 1; i < maara + 1; i++)
            {
                if (vastaukset[i - 1] != 0)
                {

                    DataPoint piste = new DataPoint();
                    piste.AxisLabel = kysymykset[i - 1];
                    piste.YValues[0] = vastaukset[i - 1];
                    points.Add(piste);
                }


            }

            pie.Visible = true;
        }

        else
            pie.Visible = false;


        List<string> vast = (List<string>)Session["vastattu"];
        int curr = (int)Session["current"];

        if (vast.Contains(curr.ToString()))
        {
            btn.Enabled = false;
        }


    }
}