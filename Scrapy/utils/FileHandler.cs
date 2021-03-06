﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scrapy.Models;

namespace Scrapy.utils
{
    class FileHandler
    {
        public Job[] getJobs()
        {
            Queue<String> list = new Queue<String>();
            StreamReader sr = new StreamReader("data.txt", Encoding.UTF8);
            String line;
            String temp=null;
            bool mark = false;
            while ((line = sr.ReadLine()) != null)
            {
                if (line.Contains("公司简介"))
                {
                    list.Enqueue(line);
                    do
                    {
                        temp = sr.ReadLine();
                    } while (!temp.Contains("公司名称"));
                    mark = true;
                }
                if (mark == false)
                {
                    list.Enqueue(line);
                }
                else
                {
                    list.Enqueue(temp);
                    mark = false;
                }
            }
            Job[] jobs = new Job[1000];
            int i = 0;
            while(i<1000)
            {
                String[] job = new String[7];
                for(int j=0;j<7;j++)
                {
                    job[j]= list.Dequeue();
                }
                list.Dequeue();
                jobs[i] = new Job(job);
                i++;
            }
            

            return jobs;

        }
    }
}
