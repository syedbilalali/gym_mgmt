﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZXing.Common;
using ZXing.QrCode;
using System.IO;
using ZXing;
using System.Drawing;
using System.Drawing.Imaging;
using gym_mgmt_01.Models;

namespace gym_mgmt_01.Controllers
{
    public class QRGenerateController : Controller
    {
        public ActionResult Index() {
            return View();
        }
        [HttpPost]
        public ActionResult Generate(QRCodeModel qrcode)
        {
            try
            {
                qrcode.QRCodeImagePath = GenerateQRCode(qrcode.QRCodeText);
                ViewBag.Message = "QR Code Created successfully";
            }
            catch (Exception ex)
            {
                //catch exception if there is any
            }
            return View("Index", qrcode);
        }

        private string GenerateQRCode(string qrcodeText)
        {
            string folderPath = "~/Images/";
            string imagePath = "~/Images/QrCode.jpg";
            // If the directory doesn't exist then create it.
            if (!Directory.Exists(Server.MapPath(folderPath)))
            {
                Directory.CreateDirectory(Server.MapPath(folderPath));
            }

            var barcodeWriter = new BarcodeWriter();
            barcodeWriter.Format = BarcodeFormat.QR_CODE;
            var result = barcodeWriter.Write(qrcodeText);

            string barcodePath = Server.MapPath(imagePath);
            var barcodeBitmap = new Bitmap(result);
            using (MemoryStream memory = new MemoryStream())
            {
                using (FileStream fs = new FileStream(barcodePath, FileMode.Create, FileAccess.ReadWrite))
                {
                    barcodeBitmap.Save(memory, ImageFormat.Jpeg);
                    byte[] bytes = memory.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
            return imagePath;
        }
    }
}