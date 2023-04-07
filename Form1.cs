using System.Reflection;

namespace assign_6_q2
{
    public class CActLine
    {
        public int XS, YS, XE, YE;
        public int Thickness;
        public Color clr;
    }

    public class CActDownDayra
    {
        public int X, Y, W, H;
        public Color clr;
        public int id;
    }
    public class image
    {
        public Bitmap img;
    }
    public partial class Form1 : Form
    {
        List<image> pic = new List<image>();
        List<CActLine> LLines = new List<CActLine>();
        List<CActDownDayra> L1 = new List<CActDownDayra>();
        List<CActDownDayra> L2   = new List<CActDownDayra>();
        List<CActDownDayra> L3 = new List<CActDownDayra>();
        List<image> im= new List<image>();
        Random RR = new Random();
        int f = 0;
        int ind = 0;
        int Num = 2;
        int h = 520,ct=1;
        int k = 0;
        int yy = 850,xx=530;
        int height = 50,width=190;
        int y2 = 880,x2=900;
        int y3=880,x3=1300;
        int ff = 0;
        int width33 = 30;
        int height33 = 30;
        bool isDrag = false;
        int xOld = -1;
        int yOld = -1;
        int iSel = -1;

        int xOld3laWad3o;
        int yOld3laWad3o;

        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            this.Load += new EventHandler(Form1_Load);
            this.Paint += new PaintEventHandler(Form1_Paint);
            this.MouseDown += new MouseEventHandler(Form1_MouseDown);
            this.MouseMove += new MouseEventHandler(Form1_MouseMove);
            this.MouseUp += new MouseEventHandler(Form1_MouseUp);
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
        }

        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && f == 0)
            {
                f++;
                DrawScene();
            }
            if (e.KeyCode == Keys.F1)
            { 
                ct++;
                // DrawScene();

                L1.Clear();
                L2.Clear();
                L3.Clear();
                Createl1();
                DrawScene();
            }
            if (e.KeyCode == Keys.F2)
            {
                ct--;
                // DrawScene();

                L1.Clear();
                L2.Clear();
                L3.Clear();
                Createl1();
                DrawScene();
            }
        }

        void Form1_MouseUp(object sender, MouseEventArgs e)
        {

            isDrag = false;
            if (iSel != -1)
            {
                if (ff == 1)
                {
                    if (L2.Count == 0 && L1[iSel].X > 700 && L1[iSel].X < 900)
                    {
                        CActDownDayra ptrav = L1[iSel];
                        L1.RemoveAt(iSel);
                        ptrav.Y = y2;
                        ptrav.X = x2;
                        L2.Add(ptrav);
                        y2 -= 70;
                    }
                    else
                    {
                        if (L1[iSel].X > 700 && L1[iSel].X < 900 && L2[L2.Count - 1].id < L1[iSel].id)
                        {
                            CActDownDayra ptrav = L1[iSel];
                            L1.RemoveAt(iSel);
                            ptrav.Y = y2;
                            ptrav.X = x2;
                            L2.Add(ptrav);
                            y2 -= 70;
                        }
                        else
                        {
                            if (L3.Count == 0 && L1[iSel].X > 1100 && L1[iSel].X < 1300)
                            {
                                CActDownDayra ptrav = L1[iSel];
                                L1.RemoveAt(iSel);
                                ptrav.Y = y3;
                                ptrav.X = x3;
                                L3.Add(ptrav);
                                y3 -= 70;
                            }
                            else
                            {
                                if (L1[iSel].X > 1100 && L1[iSel].X < 1300 && L3[L3.Count - 1].id < L1[iSel].id)
                                {
                                    CActDownDayra ptrav = L1[iSel];
                                    L1.RemoveAt(iSel);
                                    ptrav.Y = y3;
                                    ptrav.X = x3;
                                    L3.Add(ptrav);
                                    y3 -= 70;
                                }
                                else
                                {
                                    L1[iSel].X = xOld3laWad3o;
                                    L1[iSel].Y = yOld3laWad3o;
                                }
                            }
                        }
                    }
                }

                if (ff == 2)
                {
                    if (L1.Count == 0 && L2[iSel].X >= 300 && L2[iSel].X < 500)
                    {
                        CActDownDayra ptrav = L2[iSel];
                        ptrav.W = L2[iSel].W;
                        ptrav.H = L2[iSel].H;
                        L2.RemoveAt(iSel);
                        y2 += 70;
                        ptrav.Y = 870;
                        ptrav.X = 460;

                        L1.Add(ptrav);
                    }
                    else if (L2[iSel].X >= 300 && L2[iSel].X < 500 && L1[L1.Count - 1].id < L2[iSel].id)
                    {
                        CActDownDayra ptrav = L2[iSel];
                        ptrav.W = L2[iSel].W;
                        ptrav.H = L2[iSel].H;
                        L2.RemoveAt(iSel);
                        y2 += 70;  
                        ptrav.Y = L1[L1.Count - 1].Y - 70;
                        ptrav.X = L1[L1.Count - 1].X;
                       
                        L1.Add(ptrav);
                        //y2 -= 70;
                    }
                    else
                    {
                        if (L3.Count == 0 && L2[iSel].X > 1100 && L2[iSel].X < 1300)
                        {
                            CActDownDayra ptrav = L2[iSel];
                            L2.RemoveAt(iSel);
                            y2 += 70;
                            ptrav.Y = y3;
                            ptrav.X = x3;
                            L3.Add(ptrav);
                            y3 -= 70;
                        }
                        else
                        {



                            if (L2[iSel].X > 1100 && L2[iSel].X < 1300 && L3[L3.Count - 1].id < L2[iSel].id)
                            {
                                CActDownDayra ptrav = L2[iSel];
                                L2.RemoveAt(iSel);
                                y2 += 70;
                                ptrav.Y = y3;
                                ptrav.X = x3;
                                L3.Add(ptrav);
                                y3 -= 70;
                            }

                            else
                            {
                                L2[iSel].X = xOld3laWad3o;
                                L2[iSel].Y = yOld3laWad3o;
                            }
                            //else
                            //{
                            //    if (L2[iSel].X > 1100 && L2[iSel].X < 1300 && L3[L3.Count - 1].id < L2[iSel].id)
                            //    {
                            //        CActDownDayra ptrav = L2[iSel];
                            //        L2.RemoveAt(iSel);
                            //        y2 += 70;
                            //        ptrav.Y = y3;
                            //        ptrav.X = x3;
                            //        L3.Add(ptrav);
                            //        y3 -= 70;
                            //    }
                              // }

                        }
                    }
                }
                //////////
                ///
                if (ff == 3)
                {
                    if (L1.Count == 0 && L3[iSel].X >= 300 && L3[iSel].X < 500)
                    {
                        CActDownDayra ptrav = L3[iSel];
                        ptrav.W = L3[iSel].W;
                        ptrav.H = L3[iSel].H;
                        L3.RemoveAt(iSel);
                        y3 += 70;
                        ptrav.Y = 870;
                        ptrav.X = 460;

                        L1.Add(ptrav);
                    }
                    else if (L3[iSel].X >= 300 && L3[iSel].X < 500 && L1[L1.Count - 1].id < L3[iSel].id)
                    {
                        CActDownDayra ptrav = L3[iSel];
                        ptrav.W = L3[iSel].W;
                        ptrav.H = L3[iSel].H;
                        L3.RemoveAt(iSel);
                        y3 += 70;
                        ptrav.Y = L1[L1.Count - 1].Y - 70;
                        ptrav.X = L1[L1.Count - 1].X;
                        
                        L1.Add(ptrav);
                        //y2 -= 70;
                    }
                    else
                    {
                        if (L3[iSel].X > 700 && L3[iSel].X < 900 && L2.Count == 0)
                        {
                            CActDownDayra ptrav = L3[iSel];
                            L3.RemoveAt(iSel);
                            y3 += 70;
                            ptrav.Y = y2;
                            ptrav.X = x2;
                            //ptrav.W = width33;
                            //ptrav.H = height33;
                            width33 += 30;
                           // height33 += 30;
                            L2.Add(ptrav);
                            y2 -= 70;
                        }
                        else
                        {

                            ///////////////
                            if ( L3[iSel].X > 300 && L3[iSel].X < 500)
                            {
                                CActDownDayra ptrav = L3[iSel];
                                L3.RemoveAt(iSel);
                                y3 += 70;
                                ptrav.Y = L1[L1.Count-1].Y-70;
                                ptrav.X = L1[L1.Count - 1].X;
                                L1.Add(ptrav);
                                //yy -= 70;
                            }
                            else
                            {
                                //////////
                                if (L3[iSel].X > 700 && L3[iSel].X < 900 && L2[L2.Count - 1].id < L3[iSel].id)
                                {
                                    CActDownDayra ptrav = L3[iSel];
                                    L3.RemoveAt(iSel);
                                    y3 += 70;
                                    ptrav.Y = y2;
                                    ptrav.X = x2;
                                    L2.Add(ptrav);
                                    y2 -= 70;
                                }
                                else
                                {
                                    L3[iSel].X = xOld3laWad3o;
                                    L3[iSel].Y = yOld3laWad3o;
                                }
                            }

                        }
                    }
                }


            }
            iSel = -1;
            if (L3.Count == Num + ct || L2.Count == Num + ct)
            {
                ct++;
                L1.Clear();
                L2.Clear();
                L3.Clear();
                Createl1();
            }
            DrawScene();
        }
        void drawanimation()
        {
            image pnn = new image();

            pnn.img = new Bitmap(@"C:\Users\Fearless\Downloads\ASSIGNMENT 6\Tower Game\pics\motion\pic-1.png");
            im.Add(pnn);

            pnn = new image();

            pnn.img = new Bitmap(@"C:\Users\Fearless\Downloads\ASSIGNMENT 6\Tower Game\pics\motion\pic-2.png");
            im.Add(pnn);

            pnn = new image();

            pnn.img = new Bitmap(@"C:\Users\Fearless\Downloads\ASSIGNMENT 6\Tower Game\pics\motion\pic-3.png");
            im.Add(pnn);


            pnn = new image();

            pnn.img = new Bitmap(@"C:\Users\Fearless\Downloads\ASSIGNMENT 6\Tower Game\pics\motion\pic-4.png");
            im.Add(pnn);

            pnn = new image();

            pnn.img = new Bitmap(@"C:\Users\Fearless\Downloads\ASSIGNMENT 6\Tower Game\pics\motion\pic-5.png");
            im.Add(pnn);

            pnn = new image();

            pnn.img = new Bitmap(@"C:\Users\Fearless\Downloads\ASSIGNMENT 6\Tower Game\pics\motion\pic-6.png");
            im.Add(pnn);

            pnn = new image();

            pnn.img = new Bitmap(@"C:\Users\Fearless\Downloads\ASSIGNMENT 6\Tower Game\pics\motion\pic-7.png");
            im.Add(pnn);

            pnn = new image();

            pnn.img = new Bitmap(@"C:\Users\Fearless\Downloads\ASSIGNMENT 6\Tower Game\pics\motion\pic-8.png");
            im.Add(pnn);

        }
        void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(ct==9)
            {
                Graphics g = this.CreateGraphics();
               // g.Clear(Color.Black);
                if (ind==8)
                {
                    ind = 0;
                }
               
                g.DrawImage(im[ind].img, 0, 0, im[ind].img.Width, im[ind].img.Height);
                ind++;
               
                DrawScene();

            }
            if (isDrag)
            {
                int dxDrag = e.X - xOld;
                int dyDrag = e.Y - yOld;
                if (ff == 1&&iSel+1==L1.Count)
                {
                    L1[iSel].X += dxDrag;
                    L1[iSel].Y += dyDrag;
                }
                if(ff==2 && iSel + 1 == L2.Count)
                {
                    L2[iSel].X += dxDrag;
                    L2[iSel].Y += dyDrag;
                }
                if (ff == 3 && iSel + 1 == L3.Count)
                {
                    L3[iSel].X += dxDrag;
                    L3[iSel].Y += dyDrag;
                }
                xOld = e.X;
                yOld = e.Y;
                DrawScene();
            }
        }

        int isHit(int XM, int YM)
        {
            if ((XM >= 470 && XM < 630))
            {
                for (int i = 0; i < L1.Count; i++)
                {
                    if ((XM >= L1[i].X || XM <= L1[i].X - 20)
                        && XM <= (L1[i].X + L1[i].W)
                        && YM >= L1[i].Y
                        && YM <= (L1[i].Y + L1[i].H)
                        )
                    {
                        ff = 1;
                        return i;
                        
                    }
                }
            }
            if ((XM >= 780 && XM < 950))
            {
                for (int i = 0; i < L2.Count; i++)
                {
                    if ((XM >= L2[i].X || XM <= L2[i].X - 20)
                        && XM <= (L2[i].X + L2[i].W)
                        && YM >= L2[i].Y
                        && YM <= (L2[i].Y + L2[i].H)
                        )
                    {
                        ff = 2;
                        return i;
                    }
                }
            }

            if ((XM >= 1250 && XM < 1420))
            {
                for (int i = 0; i < L3.Count; i++)
                {
                    if ((XM >= L3[i].X || XM <= L3[i].X - 15)
                        && XM <= (L3[i].X + L3[i].W)
                        && YM >= L3[i].Y
                        && YM <= (L3[i].Y + L3[i].H)
                        )
                    {
                        ff = 3;
                        return i;

                    }
                }
            }
            //for (int i = 0; i < L1.Count; i++)
            //{
            //    if (XM >= L1[i].X
            //        && XM <= (L1[i].X + L1[i].W)
            //        && YM >= L1[i].Y
            //        && YM <= (L1[i].Y + L1[i].H)
            //        )
            //    {
            //        return i;
            //    }
            //}
            return -1;
        }

        void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            iSel = isHit(e.X, e.Y);

            if (iSel != -1)
            {
                isDrag = true;
                xOld = e.X;
                yOld = e.Y;
                if(ff==1)
                {
                    xOld3laWad3o =L1[iSel].X ;
                    yOld3laWad3o = L1[iSel].Y;
                }
                if(ff==2)
                {
                    xOld3laWad3o = L2[iSel].X;
                    yOld3laWad3o = L2[iSel].Y;
                }
                if (ff == 3)
                {
                    xOld3laWad3o = L3[iSel].X;
                    yOld3laWad3o = L3[iSel].Y;
                }


            }
        }

        //#region Function: Prevent Control Flickering
        //static void SetDoubleBuffer(Control ctl, bool DoubleBuffered)
        //{
        //    try
        //    {
        //        typeof(Control).InvokeMember("DoubleBuffered",
        //        BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
        //        null, ctl, new object[] { DoubleBuffered });
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        //#endregion

        void Form1_Load(object sender, EventArgs e)
        {
            CreateLine();
            Createl1();
            drawanimation();
        }

        void Createl1()
        {

            for (int i = 0; i < (Num+ct); i++)
            {
                CActDownDayra pnn = new CActDownDayra();
                pnn.W = width;
                pnn.H = height;

                pnn.X = xx-70;
                pnn.Y = yy + 20;
                pnn.clr = Color.Blue;
                pnn.id = i;

                L1.Add(pnn);
                yy -= 60;
                xx += 5;
                width -= 15;
                height -= 3;

                if (i == (Num+ct-1))
                    pnn.H = height + 8;
                if (i >= 4)
                    yy += 10;
                if (i > 7)
                   xx += 5;
            }
            yy = 850;
            xx = 520;
            height = 50;
            width = 190;
            y2 = 880; x2 = 900;
            y3 = 880; x3 = 1300;
        }

        void CreateLine()
        {
            for (int i = 0; i < 3; i++)
            {
                CActLine pnn = new CActLine();
                pnn.XS = h+20;
                pnn.YS = this.ClientSize.Height / 3;
                pnn.XE = h+20;
                pnn.YE = this.ClientSize.Height-100;
                pnn.clr = Color.White;
                pnn.Thickness = 10;
                LLines.Add(pnn);
                h += 400;
            }
           
        }

        void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawScene();            
        }
  
        void DrawScene()
        {
            //TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            Graphics go = this.CreateGraphics();
            image pnn = new image();

            if (f == 0)
            {
                //pnn.img = new Bitmap(@"C:\Users\Fearless\Downloads\ASSIGNMENT 6\pic-8\pic-1.png");
                //go.DrawImage(pnn.img, 0, 0, pnn.img.Width, pnn.img.Height);
                go.Clear(Color.PowderBlue);
                Font Fnt5 = new Font("System", 25);
                go.DrawString("1. Arrange the same pattern in another tower.", Fnt5, Brushes.Black, 500, 300);
                go.DrawString("2. You can only drag the box in the top", Fnt5, Brushes.Black, 500, 400);
                go.DrawString("3. There are 8 levels in the game", Fnt5, Brushes.Black, 500, 500);
                Font Fnt6 = new Font("System", 30);
                go.DrawString("Press Enter to start the game ", Fnt6, Brushes.Black,700, 800);
                // ct++;
            }
            else
            {
                if (ct == 1)

                {
                    pnn.img = new Bitmap(@"C:\Users\Fearless\Downloads\ASSIGNMENT 6\Tower Game\pics\pic-1.jpg");
                    go.DrawImage(pnn.img, 0, 0, pnn.img.Width, pnn.img.Height);
                }
                else if (ct == 2)
                {
                    pnn.img = new Bitmap(@"C:\Users\Fearless\Downloads\ASSIGNMENT 6\Tower Game\pics\pic-2.png");
                    go.DrawImage(pnn.img, 0, 0, pnn.img.Width, pnn.img.Height);
                }
                else if (ct == 3)
                {
                    pnn.img = new Bitmap(@"C:\Users\Fearless\Downloads\ASSIGNMENT 6\Tower Game\pics\pic-3.jpg");
                    go.DrawImage(pnn.img, 0, 0, pnn.img.Width, pnn.img.Height);
                }
                else if (ct == 4)
                {
                    pnn.img = new Bitmap(@"C:\Users\Fearless\Downloads\ASSIGNMENT 6\Tower Game\pics\pic-4.jpg");
                    go.DrawImage(pnn.img, 0, 0, pnn.img.Width, pnn.img.Height);
                }
                else if (ct == 5)
                {
                    pnn.img = new Bitmap(@"C:\Users\Fearless\Downloads\ASSIGNMENT 6\Tower Game\pics\pic-5.jpg");
                    go.DrawImage(pnn.img, 0, 0, pnn.img.Width, pnn.img.Height);
                }
                else if (ct == 6)
                {
                    pnn.img = new Bitmap(@"C:\Users\Fearless\Downloads\ASSIGNMENT 6\Tower Game\pics\pic-6.jpg");
                    go.DrawImage(pnn.img, 0, 0, pnn.img.Width, pnn.img.Height);
                }
                else if (ct == 7)
                {
                    pnn.img = new Bitmap(@"C:\Users\Fearless\Downloads\ASSIGNMENT 6\Tower Game\pics\pic-7.jpg");
                    go.DrawImage(pnn.img, 0, 0, pnn.img.Width, pnn.img.Height);
                }

                else if (ct == 8)
                {
                    pnn.img = new Bitmap(@"C:\Users\Fearless\Downloads\ASSIGNMENT 6\Tower Game\pics\pic-8.jpg");
                    go.DrawImage(pnn.img, 0, 0, pnn.img.Width, pnn.img.Height);
                }
                else
                {
                   // go.Clear(Color.Black);
                    DoubleBuffered = true;
                    
                       
                   
                    pnn.img = new Bitmap(@"C:\Users\Fearless\Downloads\ASSIGNMENT 6\Tower Game\pics\motion\pic-1.png");
                    go.DrawImage(pnn.img, 0, 0, pnn.img.Width, pnn.img.Height);
                    go.Clear(Color.Black);
                    Font Fnt1 = new Font("System", 40);
                    go.DrawString("Congratulations, ", Fnt1, Brushes.White, 200, 120);
                    go.DrawString("You Won!!", Fnt1, Brushes.White, 1300, 120);

                    Font Fnt2 = new Font("System", 50);
                    go.DrawString("Move the", Fnt2, Brushes.White, 200, 500);
                    go.DrawString("Mouse.", Fnt2, Brushes.White, 1300, 500);
                }

                if (ct < 9)
                {
                    Font Fnt1 = new Font("System", 30);
                    go.DrawString(ct + "/8", Fnt1, Brushes.White, 900, 120);
                    for (int i = 0; i < LLines.Count; i++)
                    {
                        Pen Pn = new Pen(LLines[i].clr, LLines[i].Thickness);
                        go.DrawLine(Pn, LLines[i].XS, LLines[i].YS, LLines[i].XE, LLines[i].YE);
                    }

                    Font Fnt = new Font("System", 20);
                    for (int i = 0; i < L1.Count; i++)
                    {
                        Pen Pn = new Pen(Color.DarkTurquoise, 5);
                        SolidBrush brsh = new SolidBrush(Color.Black);
                        go.FillRectangle(brsh, L1[i].X, L1[i].Y, L1[i].W, L1[i].H);
                        go.DrawRectangle(Pn, L1[i].X, L1[i].Y, L1[i].W, L1[i].H);
                        //g.DrawString(L1 [i].id+"" , Fnt , Brushes.Black , L1 [i].X +5, L1[i].Y+5);
                    }

                    for (int i = 0; i < L2.Count; i++)
                    {
                        Pen Pn = new Pen(Color.DarkTurquoise, 5);
                        SolidBrush brsh = new SolidBrush(Color.Black);
                        go.FillRectangle(brsh, L2[i].X, L2[i].Y, L2[i].W, L2[i].H);
                        go.DrawRectangle(Pn, L2[i].X, L2[i].Y, L2[i].W, L2[i].H);
                        // g.DrawString(L2[i].id + "", Fnt, Brushes.Black, L2[i].X + 5, L2[i].Y + 5);
                    }
                    for (int i = 0; i < L3.Count; i++)
                    {

                        Pen Pn = new Pen(Color.DarkTurquoise, 5);
                        SolidBrush brsh = new SolidBrush(Color.Black);
                        go.FillRectangle(brsh, L3[i].X, L3[i].Y, L3[i].W, L3[i].H);
                        go.DrawRectangle(Pn, L3[i].X, L3[i].Y, L3[i].W, L3[i].H);
                        //g.DrawString(L3[i].id + "", Fnt, Brushes.Black, L3[i].X + 5, L3[i].Y + 5);
                    }
                }
            }
        }
    }
}