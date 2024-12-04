# Contributing Guide

Thank you for your interest in contributing to the CUDA Environment Tester! This guide will help you get started.

## Table of Contents
- [Code of Conduct](#code-of-conduct)
- [Getting Started](#getting-started)
- [Development Workflow](#development-workflow)
- [Pull Request Process](#pull-request-process)
- [Coding Standards](#coding-standards)
- [Testing Guidelines](#testing-guidelines)

## Code of Conduct

- Be respectful and inclusive
- Provide constructive feedback
- Follow project guidelines
- Help others learn and grow

## Getting Started

1. **Fork and Clone**
   ```bash
   git clone https://github.com/YOUR-USERNAME/CudaEnvironmentTester.git
   cd CudaEnvironmentTester
   ```

2. **Set Up Development Environment**
   - Install prerequisites from [Installation Guide](installation.md)
   - Set up your IDE (Visual Studio 2022 recommended)
   - Install recommended extensions

3. **Create Feature Branch**
   ```bash
   git checkout -b feature/library-name-test
   ```

## Development Workflow

### 1. Choose an Issue
- Check [open issues](../../issues)
- Comment on issue you want to work on
- Wait for assignment/confirmation

### 2. Implementation Steps
1. Create new test class in `LibraryTests/`
2. Follow [Implementation Guide](implementation.md)
3. Add documentation
4. Test thoroughly
5. Update README if needed

### 3. Commit Guidelines
```bash
# Format: <type>: <description>
feat: Add cuDNN test implementation
fix: Correct version check in cuTENSOR test
docs: Update implementation guide
```

Types:
- `feat`: New feature
- `fix`: Bug fix
- `docs`: Documentation
- `refactor`: Code refactoring
- `test`: Adding tests
- `chore`: Maintenance

## Pull Request Process

1. **Before Submitting**
   - [ ] Tests pass locally
   - [ ] Documentation updated
   - [ ] Code follows standards
   - [ ] Commits are clean

2. **PR Template**
   ```markdown
   ## Description
   Brief description of changes

   ## Changes
   - Added X
   - Modified Y
   - Fixed Z

   ## Testing
   - Test steps
   - Expected results

   Fixes #issue_number
   ```

3. **Review Process**
   - Address reviewer feedback
   - Keep PR updated with main
   - Be responsive to comments

## Coding Standards

### 1. C# Guidelines
```csharp
// Use PascalCase for public members
public class CudnnTest : CudaLibraryTestTemplate
{
    // Use readonly where possible
    private readonly string _version;

    // XML documentation for public APIs
    /// <summary>
    /// Initializes the test
    /// </summary>
    protected override void Initialize()
    {
        // Implementation
    }
}
```

### 2. Documentation
- Use XML comments
- Keep README updated
- Document breaking changes
- Include examples

### 3. Testing
- Write meaningful tests
- Cover error cases
- Test resource cleanup
- Document test requirements

## Testing Guidelines

1. **Local Testing**
   ```bash
   dotnet build
   dotnet run
   ```

2. **Test Requirements**
   - All tests must pass
   - No memory leaks
   - Proper error handling
   - Clear output messages

3. **Test Documentation**
   - Test prerequisites
   - Expected results
   - Error scenarios
   - Performance implications

## Recognition

Contributors will be:
- Listed in README
- Mentioned in release notes
- Given credit in documentation

## Questions?

- Create an issue
- Ask in PR comments
- Check existing documentation

## See Also
- [Implementation Guide](implementation.md)
- [Usage Guide](usage.md)
- [Test Output Examples](test-output.md) 