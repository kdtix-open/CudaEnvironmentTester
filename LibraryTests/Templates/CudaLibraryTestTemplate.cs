namespace CudaEnvironmentTester.LibraryTests.Templates
{
    /// <summary>
    /// Template version 1.0.0
    /// Base template for CUDA library testing implementations.
    /// </summary>
    /// <remarks>
    /// Change Log:
    /// v1.0.0 - Initial template with basic test lifecycle methods
    /// </remarks>
    public abstract class CudaLibraryTestTemplate : ICudaLibraryTest
    {
        /// <summary>
        /// Gets the template version used by this implementation
        /// </summary>
        public virtual string TemplateVersion => "1.0.0";

        /// <summary>
        /// Gets the name of the CUDA library being tested
        /// </summary>
        public abstract string LibraryName { get; }

        /// <summary>
        /// Gets the version of the CUDA library being tested
        /// </summary>
        public abstract string LibraryVersion { get; }

        /// <summary>
        /// Executes the test sequence in the defined order
        /// </summary>
        public void RunTest()
        {
            try
            {
                Console.WriteLine($"Using template version: {TemplateVersion}");
                Initialize();
                VerifyVersion();
                ExecuteTests();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Test failed: {ex.Message}");
                throw;
            }
            finally
            {
                try
                {
                    Cleanup();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Cleanup failed: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Initializes the library and required resources
        /// </summary>
        /// <remarks>
        /// Implement library initialization, context creation, and resource allocation
        /// </remarks>
        protected abstract void Initialize();

        /// <summary>
        /// Verifies the library version matches the expected version
        /// </summary>
        /// <remarks>
        /// Implement version checking and compatibility verification
        /// </remarks>
        protected abstract void VerifyVersion();

        /// <summary>
        /// Executes the core library tests
        /// </summary>
        /// <remarks>
        /// Implement specific library functionality tests
        /// </remarks>
        protected abstract void ExecuteTests();

        /// <summary>
        /// Cleans up resources and handles disposal
        /// </summary>
        /// <remarks>
        /// Implement resource cleanup, context disposal, and memory freeing
        /// </remarks>
        protected abstract void Cleanup();
    }
} 