﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionCore;
using CompareDelegateCore;

namespace CollectionWithEventsProgram
{
    class Program
    {
        static SinglyLinkedList<int> DeletedItems = new SinglyLinkedList<int>();
        static void Main(string[] args)
        {
            bool a = Compare<int>.RhsIsGreater(15, 20);


            SinglyLinkedList<int> TestList = new SinglyLinkedList<int>();
            SinglyLinkedList<int> TestList2 = new SinglyLinkedList<int>();

            SinglyLinkedList<int> TestList3 = new SinglyLinkedList<int>();

            TestList2.Event += delegate(object sender, OnDeleteArgs<int> e)
            {
                if (!TestList3.Contains(e.Item))
                {
                    TestList3.AddItem(e.Item);
                }
                
            };
                //SinglyLinkedList_Event;

            TestList.AddItem(6);
            TestList.AddItem(7);
            TestList.AddItem(5);
            TestList.AddItem(71);

            for (int i = 0; i < 10; i++)
            {
                TestList2.AddItem(i);
            }

            TestList2.Except(TestList);

            int A = TestList[1];

            TestList[0] = 10;

            TestList.DeleteItem(6);

            TestList.SortList(Compare<int>.RhsIsGreater);

            for (int i = 0; i < DeletedItems.Size; i++)
                Console.WriteLine(DeletedItems[i].ToString());

            Console.ReadLine();

        }

        static void SinglyLinkedList_Event(object sender, OnDeleteArgs<int> e)
        {
            switch (e.Message)
            {
                case "Remove":
                    {
                        if (!DeletedItems.Contains(e.Item))
                        {
                            DeletedItems.AddItem(e.Item);
                        }
                    }
                    break;
            }
        }
    }

}
