namespace CudaEnvironmentTester.LibraryTests
{
    /// <summary>
    /// Interface defining the contract for CUDA library tests
    /// </summary>
    /// <remarks>
    /// This interface is implemented by CudaLibraryTestTemplate and used by all library tests.
    /// See README.md "Implementation Guide" section for usage details.
    /// 
    /// TODO: Future Enhancements
    /// - Add test priority levels (#15)
    /// - Add test dependencies declaration (#16)
    /// - Add test requirements validation (#17)
    /// </remarks>
    public interface ICudaLibraryTest
    {
        /// <summary>
        /// Gets the name of the CUDA library being tested
        /// </summary>
        string LibraryName { get; }

        /// <summary>
        /// Gets the version of the CUDA library being tested
        /// </summary>
        string LibraryVersion { get; }

        /// <summary>
        /// Executes the library test sequence
        /// </summary>
        void RunTest();
    }
} 