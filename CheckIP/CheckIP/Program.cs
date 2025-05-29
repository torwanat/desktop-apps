using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;

namespace CheckIP
{
    class Program
    {
        static void Main(string[] args)
        {
            string HostName = Dns.GetHostName();
            IPHostEntry AddressesIP = Dns.GetHostEntry(HostName);
            Console.WriteLine("Host name: " + HostName);
            int counter = 0;
            foreach(IPAddress AddressIP in AddressesIP.AddressList)
            {
                if (AddressIP.ToString() == "127.0.0.1")
                    Console.WriteLine("The computer is not connected to a network. Address IP: " + AddressIP.ToString());
                else
                    Console.WriteLine(" address IP #" + ++counter + ": " + AddressIP.ToString());
            }
            Console.WriteLine("Aktualne połączenia TCP/IP typu klient: ");
            foreach(TcpConnectionInformation connectTcp in IPGlobalProperties.GetIPGlobalProperties().GetActiveTcpConnections())
            {
                Console.WriteLine("  Zdalny adres: " + connectTcp.RemoteEndPoint.Address.ToString() + ": " + connectTcp.RemoteEndPoint.Port);
                Console.WriteLine("   Status: " + connectTcp.State.ToString());
            }
            Console.WriteLine("Aktualne połączenia TCP/IP typu serwer: ");
            foreach (IPEndPoint connectTcp in IPGlobalProperties.GetIPGlobalProperties().GetActiveTcpListeners())
            {
                Console.WriteLine("   Zdalny adres: " + connectTcp.Address.ToString() + ": " + connectTcp.Port);
            }
            Console.WriteLine("Aktualne połączenie UDP: ");
            foreach(IPEndPoint connectUdp in IPGlobalProperties.GetIPGlobalProperties().GetActiveTcpListeners())
            {
                Console.WriteLine("   Zdalny adres: " + connectUdp.Address.ToString() + ": " + connectUdp.Port);
            }
            counter = 0;
            IPGlobalProperties propertiesIP = IPGlobalProperties.GetIPGlobalProperties();
            Console.WriteLine("Nazwa hosta: " + propertiesIP.HostName);
            Console.WriteLine("Nazwa domeny: " + propertiesIP.DomainName);
            Console.WriteLine();

            foreach(NetworkInterface netCards in NetworkInterface.GetAllNetworkInterfaces())
            {
                Console.WriteLine("Karta #" + ++counter + ": " + netCards.Id);
                Console.WriteLine("Adres MAC: " + netCards.GetPhysicalAddress().ToString());
                Console.WriteLine("Opis: " + netCards.Description);
                Console.WriteLine("Status: " + netCards.OperationalStatus);
                Console.WriteLine("Szybkość: " + (netCards.Speed)/(double)1000)
                Console.WriteLine
            }
            Console.ReadKey();
        }
    }
}
