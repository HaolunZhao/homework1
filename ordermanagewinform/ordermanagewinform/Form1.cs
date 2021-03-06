﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace ordermanagewinform
{
    public partial class Form1 : Form
    {

        public string KeyWord { get; set; }
        public OrderItem apple;
        public OrderItem egg;
        public OrderItem milk;


        public Order order1;
        public Order order2;
        public Order order3;

        public OrderService os = new OrderService();

        string fileName = @"./orders.xml";
        public Form1()
        {
            InitializeComponent();
            apple = new OrderItem(1, "apple", 10.0, 80);
            egg = new OrderItem(2, "eggs", 1.2, 200);
            milk = new OrderItem(3, "milk", 50, 10);

            order1 = new Order(1, "Customer1", new List<OrderItem> { apple, egg, milk });
            order2 = new Order(2, "Customer2", new List<OrderItem> { egg, milk });
            order3 = new Order(3, "Customer2", new List<OrderItem> { apple, milk });

            os.AddOrder(order1);
            os.AddOrder(order2);
            os.AddOrder(order3);

            orderbindingSource.DataSource = os.Orders;

            textBox1.DataBindings.Add("Text", this, "KeyWord");

        }

        private void addbutton_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            OrderItem orderItem = new OrderItem();
            order.AddItem(orderItem);
            os.AddOrder(order);
            Form2 form2 = new Form2(order, orderItem);
            form2.Show(this);
            

        }

        private void removebutton_Click(object sender, EventArgs e)
        {
            uint orderID = (uint)dataGridView1.CurrentRow.Cells[0].Value;
            Order order = os.GetOrder(orderID);
            if (order != null)
            {
                os.Orders.Remove(order);
            }
            orderbindingSource.ResetBindings(false);
        }

        private void updatebutton_Click(object sender, EventArgs e)
        {
            uint orderID = (uint)dataGridView1.CurrentRow.Cells[0].Value;
            Order order = os.GetOrder(orderID);
            uint index = (uint)dataGridView1.CurrentRow.Cells[0].Value;
            OrderItem orderItem = order.GetItem(index);
            Form2 form2 = new Form2(order, orderItem);
            form2.Show(this);
        }

        private void importbutton_Click(object sender, EventArgs e)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                List<Order> temp = (List<Order>)xs.Deserialize(fs);
                temp.ForEach(order => {
                    if (!os.Orders.Contains(order))
                    {
                        os.Orders.Add(order);
                    }
                });
            }
        }

        private void exportbutton_Click(object sender, EventArgs e)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                xs.Serialize(fs, os.Orders);
            }
        }

        private void searchbutton_Click(object sender, EventArgs e)
        {
            if (KeyWord == null || KeyWord == "")
            {
                orderbindingSource.DataSource = os.Orders;
            }
            string check = comboBox1.Text;
            switch (check)
            {
                case "按客户名查询":
                    orderbindingSource.DataSource = os.Orders.Where(s => s.Customer == KeyWord);
                    break;
                case "按商品名查询":
                    orderbindingSource.DataSource =
                    os.Orders.Where(s => s.Items.Exists(item => item.GoodsName == KeyWord));
                    break;
            }
        }
    }

   
}
