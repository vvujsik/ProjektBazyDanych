using System.Text;
using System.Text.Json;

namespace HotelApp
{
    public partial class Form1 : Form
    {
        private HttpClient _httpClient;
        public Form1()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string call = "https://localhost:7269/HotelAssistant/GetBookings";
            string response = await _httpClient.GetStringAsync(call);
            List<Booking> rezerwacje = JsonSerializer.Deserialize<List<Booking>>(response);
            listBox1.DataSource = rezerwacje;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            String start = startDateText.Text;
            String end = endDateText.Text;

            string call = "https://localhost:7269/HotelAssistant/GetFreeRoomsByCapacityDesc?rentStartDate=" + start + "&rentEndDate=" + end;
            string response = await _httpClient.GetStringAsync(call);
            List<room> rooms = JsonSerializer.Deserialize<List<room>>(response);
            listBox2.DataSource = rooms;
        }

        private async void addbookingbutton_Click(object sender, EventArgs e)
        {
            string call = "https://localhost:7269/HotelAssistant/AddBooking?" +
                "customerId=" + customerIDTEXT.Text + "&roomId=" + roomIdText.Text + "&rentDate=" + rentDateText.Text + "&rentDuration=" + rentDurationText.Text + "&personCount=" + countText.Text;

            var content = new StringContent("", Encoding.UTF8, "application/json"); // Sending empty content for POST request

            HttpResponseMessage response = await _httpClient.PostAsync(call, content);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Response content: " + responseContent, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: " + response.StatusCode, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            string call = "https://localhost:7269/HotelAssistant/RemoveBooking?bookingId=" + bookingIdText.Text;

            HttpResponseMessage response = await _httpClient.DeleteAsync(call);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Response content: " + responseContent, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: " + response.StatusCode, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
