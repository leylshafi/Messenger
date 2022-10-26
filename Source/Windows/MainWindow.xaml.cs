using Bogus;
using Source.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Source.Windows;

public partial class MainWindow : Window
{
    public Sender Sender { get; set; }
    public List<Message> Messages { get; set; }= new List<Message>();

    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;

        Sender = new Faker<Sender>()
            .RuleFor(u => u.Firstname, faker => faker.Person.FirstName)
            .RuleFor(u => u.Lastname, faker => faker.Person.LastName)
            .RuleFor(u => u.ImageUrl, faker => faker.Person.Avatar)
            .RuleFor(u => u.Fullname, faker => $"{faker.Person.FirstName} {faker.Person.LastName}");
        
    }

    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtMsg.Text))
            return;

        listView.ItemsSource = null;
        Messages.Add(new Message()
        {
            MessageText = txtMsg.Text,
            Date=System.DateTime.Now.ToShortTimeString()
        });
        listView.ItemsSource = Messages;



        int messageSize = txtMsg.Text.Split(' ').Length;

        txtMsg.Text = string.Empty;

        StringBuilder sb = new();


        await Task.Run(() => {

            Thread.Sleep(messageSize * 700);

            Messages.Add(new Message()
            {
                MessageText= FakeMessage.FakeM()[Random.Shared.Next(0, 11)],
                Date=DateTime.Now.ToShortTimeString()
            });
        }
        );

        listView.ItemsSource = null;
        listView.ItemsSource = Messages;
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Press Win+.","Information",MessageBoxButton.OK,MessageBoxImage.Information);
    }

    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
        MessageBox.Show($"You are talking to {Sender.Fullname}. Have fun \ud83d");
    }
}
