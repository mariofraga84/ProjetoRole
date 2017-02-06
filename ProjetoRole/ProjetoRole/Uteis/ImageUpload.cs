using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProjetoRole.Uteis
{
    public class ImageUpload
    {
        // set default size here
        public int Width { get; set; }

        public int Height { get; set; }

        // folder for the upload, you can put this in the web.config
        private readonly string UploadPath = "~/Arquivos/Imagens/"; // "Items/"

        public ImageResult RenameUploadFile(HttpPostedFileBase file, Int32 counter = 0)
        {
            var fileName = Path.GetFileName(file.FileName);

            string prepend = "item_";
            string finalFileName = prepend + ((counter).ToString()) + "_" + funcoesUteis.DeixaSoNumeros(DateTime.Now.ToLongDateString()+ DateTime.Now.ToLongDateString()) + Path.GetExtension(file.FileName);
            if (System.IO.File.Exists
                (HttpContext.Current.Request.MapPath(UploadPath+"Grandes/" + finalFileName)))
            {
                //file exists => add country try again
                return RenameUploadFile(file, ++counter);
            }
            //file doesn't exist, upload item but validate first
            return UploadFile(file, finalFileName);
        }

        private ImageResult UploadFile(HttpPostedFileBase file, string fileName)
        {
            ImageResult imageResult = new ImageResult { Success = true, ErrorMessage = null };

            var path = Path.Combine(HttpContext.Current.Request.MapPath(UploadPath+"Grandes/"), fileName);
            var path2 = Path.Combine(HttpContext.Current.Request.MapPath(UploadPath+"Medias/"), fileName);
            var path3 = Path.Combine(HttpContext.Current.Request.MapPath(UploadPath+"Pequenas/"), fileName);
            var path4 = Path.Combine(HttpContext.Current.Request.MapPath(UploadPath + "Minis/"), fileName);
            string extension = Path.GetExtension(file.FileName);

            //make sure the file is valid
            if (!ValidateExtension(extension))
            {
                imageResult.Success = false;
                imageResult.ErrorMessage = "Invalid Extension";
                return imageResult;
            }

            try
            {
                file.SaveAs(path);
                Image imgOriginal = Image.FromFile(path);

                //pass in whatever value you want
                Width = 800;
                Image imgActual = Scale(imgOriginal);
                imgOriginal.Dispose();
                imgActual.Save(path);
                imgActual.Dispose();


                file.SaveAs(path2);
                Image imgOriginal2 = Image.FromFile(path2);

                //pass in whatever value you want
                Width = 560;
                Image imgActual2 = Scale(imgOriginal2);
                imgOriginal2.Dispose();
                imgActual2.Save(path2);
                imgActual2.Dispose();

                file.SaveAs(path3);
                Image imgOriginal3 = Image.FromFile(path3);

                //pass in whatever value you want
                Width = 280; 
                Image imgActual3 = Scale(imgOriginal3);
                imgOriginal3.Dispose();
                imgActual3.Save(path3);
                imgActual3.Dispose();

                file.SaveAs(path4);
                Image imgOriginal4 = Image.FromFile(path4);

                //pass in whatever value you want
                Width = 140;
                Image imgActual4 = Scale(imgOriginal4);
                imgOriginal4.Dispose();
                imgActual4.Save(path3);
                imgActual4.Dispose();


                imageResult.ImageName = fileName;

                return imageResult;
            }
            catch (Exception ex)
            {
                // you might NOT want to show the exception error for the user
                // this is generally logging or testing

                imageResult.Success = false;
                imageResult.ErrorMessage = ex.Message;
                return imageResult;
            }
        }

        private bool ValidateExtension(string extension)
        {
            extension = extension.ToLower();
            switch (extension)
            {
                case ".jpg":
                    return true;
                case ".png":
                    return true;
                case ".gif":
                    return true;
                case ".jpeg":
                    return true;
                default:
                    return false;
            }
        }

        private Image Scale(Image imgPhoto)
        {
            float sourceWidth = imgPhoto.Width;
            float sourceHeight = imgPhoto.Height;
            float destHeight = 0;
            float destWidth = 0;
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;

            // force resize, might distort image
            if (Width != 0 && Height != 0)
            {
                destWidth = Width;
                destHeight = Height;
            }
            // change size proportially depending on width or height
            else if (Height != 0)
            {
                destWidth = (float)(Height * sourceWidth) / sourceHeight;
                destHeight = Height;
            }
            else
            {
                destWidth = Width;
                destHeight = (float)(sourceHeight * Width / sourceWidth);
            }

            Bitmap bmPhoto = new Bitmap((int)destWidth, (int)destHeight,
                                        PixelFormat.Format32bppPArgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, (int)destWidth, (int)destHeight),
                new Rectangle(sourceX, sourceY, (int)sourceWidth, (int)sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();

            return bmPhoto;
        }
    }
    public class ImageResult
    {
        public bool Success { get; set; }
        public string ImageName { get; set; }
        public string ErrorMessage { get; set; }
    }
}
