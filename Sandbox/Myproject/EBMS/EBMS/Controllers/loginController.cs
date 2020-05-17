using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using EBMS.Models;

namespace EBMS.Controllers
{
    public class loginController : Controller
    {
        // GET: login
        common objcommon = new common();
        public ActionResult user_login()
        {
            //return RedirectToAction("Expired", "Session");
            Session["CAPTCHA"] = objcommon.getrandomtext();

            return View();
        }
        [HttpPost]
        public ActionResult user_login(userlogin obj,string clentcapt)
        {
            string servercaptcha=null;
            string clientcaptcha=null;

            if (Session["CAPTCHA"] == null)
            {
                Session["CAPTCHA"] = objcommon.getrandomtext();
            }
            else
            {
                servercaptcha = Session["CAPTCHA"].ToString();
                clientcaptcha = clentcapt;
                if(servercaptcha==clentcapt)
                {
                    Boolean result = objcommon.checkuser(obj.user_name1, obj.user_password);
                    if(result==true)
                    {
                        Session["user_active"] = obj.user_name1;
                        return RedirectToAction("Dash", "Dashboard");
                       
                    }
                    else
                    {
                        ViewBag.errormessage = "wrong credentials!!!!!1";
                        Session["CAPTCHA"] = objcommon.getrandomtext();
                        return View();
                    }
                }
                else
                {
                    ViewBag.errormessage = "Invalid CAptCha!!!!!!";
                    Session["CAPTCHA"] = objcommon.getrandomtext();
                    return View();
                }
                
            }
            
            return View();
        }       
        public FileResult getcaptchaimage()
        {
            if(Session["CAPTCHA"]==null)
            {
                Session["CAPTCHA"] = objcommon.getrandomtext();
            }
            string text = Session["CAPTCHA"].ToString();
            Image img = new Bitmap(1, 1);
            Graphics drawing = Graphics.FromImage(img);

            Font font = new Font("Arial", 15);
            //measure the string to see how big the image needs to be
            SizeF textSize = drawing.MeasureString(text, font);

            //free up the dummy image and old graphics object
            img.Dispose();
            drawing.Dispose();

            //create a new image of the right size
            img = new Bitmap((int)textSize.Width + 40, (int)textSize.Height + 20);
            drawing = Graphics.FromImage(img);

            Color backColor = Color.SeaShell;
            Color textColor = Color.Red;
            //paint the background
            drawing.Clear(backColor);

            //create a brush for the text
            Brush textBrush = new SolidBrush(textColor);

            drawing.DrawString(text, font, textBrush, 20, 10);

            drawing.Save();

            font.Dispose();
            textBrush.Dispose();
            drawing.Dispose();

            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            img.Dispose();

            return File(ms.ToArray(), "image/png");

        }
    }
}