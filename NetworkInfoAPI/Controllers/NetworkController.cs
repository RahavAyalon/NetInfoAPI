using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace NetworkInfoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NetworkController : ControllerBase
    {
        private readonly ILogger<NetworkController> _logger;

        public NetworkController(ILogger<NetworkController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var interfaces = NetworkInterface.GetAllNetworkInterfaces()
                    .Select(ni => new
                    {
                        ni.Name,
                        ni.Description,
                        NetworkType = ni.NetworkInterfaceType.ToString(),
                        Status = ni.OperationalStatus.ToString(),
                        IPAddresses = ni.GetIPProperties().UnicastAddresses
                            .Select(ip => ip.Address.ToString()).ToArray()
                    }).ToArray();

                _logger.LogInformation("Retrieved network interfaces successfully:");
                foreach (var iface in interfaces)
                {
                    _logger.LogInformation($"Interface: {iface.Name}, " +
                                           $"Description: {iface.Description}, " +
                                           $"Type: {iface.NetworkType}, " +
                                           $"Status: {iface.Status}, " +
                                           $"IP Addresses: {string.Join(", ", iface.IPAddresses)}");
                }

                return Ok(interfaces);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving network interfaces.");
                return StatusCode(503, "An error occurred while retrieving network interfaces.");
            }
        }
    }
}
