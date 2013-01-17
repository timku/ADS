using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADS_pract1 {
    class Program {
        static Random random;
        static int xmax, ymax;
        static void Main(string[] args) {
            // 94%
            int world_none = 0, world_total = 0;
            random = new Random();
            //Console.WriteLine("Starting at "+DateTime.Now.ToString("HH:mm:ss.ffffff"));
        beginGenerate:

            //xmax = 70;
            //ymax = 24;
            ymax = 20;
            xmax = 20;

            ADS[] entitys = new ADS[49];

            for (int i = 0; i < entitys.Length; i++) {
                entitys[i] = new ADS();
                entitys[i].obj(Rand(xmax), Rand(ymax));
                //Console.WriteLine("" + entitys[i]);
            }
            string str = "";
            int atplaceTotal = 0;
            collision(entitys,ref str,ref atplaceTotal);
            //drieOfMeer(entitys, ref str, ref atplaceTotal);
            //ondersteHelft(entitys, ref str, ref atplaceTotal);
            world_total++;
            if (atplaceTotal == 0) {
                world_none++;
                //goto beginGenerate;
            }
            if (world_total < 1000) {
                goto beginGenerate;
            }
            Console.Clear();
            Console.WriteLine(str + "\r\nTotal: " + atplaceTotal + "\r\nWorld Total: " + world_total + " / " + world_none + " (" + (((world_total-world_none)*100)/world_total) + "%)");
            Console.In.ReadLine();
            goto beginGenerate;
        }
        private static int Rand(int max) {
            //random = new Random();
            return random.Next(1, max);
        }
        // Bereken dubbele op zelfde plek
        private static void collision(ADS[] entitys, ref string str, ref int atplaceTotal) {
            int x = 0, y = 0;
            for (int c = 0; c < (xmax * (ymax+1)); c++) {
                x++;
                if (x > xmax) {
                    y++;
                    x = 1;
                    //str += " regel " + y + " num " + c; // DEBUG
                    str += "\r\n";
                }
                int atplace = 0;
                for (int i = 0; i < entitys.Length; i++) {
                    if (entitys[i].areYouAt(x, y)) {
                        atplace++;
                        if (atplace > 1) {
                            atplaceTotal++;
                        }
                    }
                }
                if (atplace > 1) {
                    str += (atplace-1);
                } else {
                    str += " ";
                }
            }
        }
        // A. Hoeveel objecten staan er in de onderste helft van de wereld?
        private static void ondersteHelft(ADS[] entitys, ref string str, ref int atplaceTotal) {
            int x = 0, y = ymax/2;
            int helft = ymax / 2;
            for (int i = 0; i < helft; i++) {
                //str += "regel " + (i + 1);
                str += "\r\n";
            }
            for (int c = 0; c < (xmax * (helft+1)); c++) {
                x++;
                if (x > xmax) {
                    y++;
                    x = 1;
                    //str += " regel " + y + " num " + c; // DEBUG
                    str += "\r\n";
                }
                int atplace = 0;
                for (int i = 0; i < entitys.Length; i++) {
                    if (entitys[i].areYouAt(x, y)) {
                        atplace++;
                        if (atplace > 1) {
                            atplaceTotal++;
                        }
                    }
                }
                if (atplace > 1) {
                    str += (atplace - 1);
                } else {
                    str += " ";
                }
            }
        }
        // C. Tel het aantal tiles waar 2 of meer objecten op staan.
        private static void drieOfMeer(ADS[] entitys, ref string str, ref int atplaceTotal) {
            int x = 0, y = 0;
            for (int c = 0; c < (xmax * (ymax+1)); c++) {
                x++;
                if (x > xmax) {
                    y++;
                    x = 1;
                    //str += " regel " + y + " num " + c; // DEBUG
                    str += "\r\n";
                }
                int atplace = 0;
                for (int i = 0; i < entitys.Length; i++) {
                    if (entitys[i].areYouAt(x, y)) {
                        atplace++;
                        if (atplace > 2) {
                            atplaceTotal++;
                        }
                    }
                }
                if (atplace > 2) {
                    str += (atplace - 1);
                } else {
                    str += " ";
                }
            }
        }

    }
}
