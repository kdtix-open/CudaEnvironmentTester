using ManagedCuda;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("CUDA Environment Test");
        
        try
        {
            // Get number of CUDA devices
            int deviceCount = CudaContext.GetDeviceCount();
            Console.WriteLine($"Number of CUDA devices: {deviceCount}");

            // Print information for each device
            for (int i = 0; i < deviceCount; i++)
            {
                using (var device = new CudaContext(i))
                {
                    var attributes = device.GetDeviceInfo();
                    Console.WriteLine($"\nDevice {i}: {attributes.DeviceName}");
                    Console.WriteLine($"Compute Capability: {attributes.ComputeCapability.Major}.{attributes.ComputeCapability.Minor}");
                    Console.WriteLine($"Total Memory: {attributes.TotalGlobalMemory / (1024 * 1024)} MB");
                    Console.WriteLine($"Clock Rate: {attributes.ClockRate / 1000} MHz");
                }
            }

            Console.WriteLine("\nCUDA environment test completed successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during CUDA test: {ex.Message}");
        }
    }
}
