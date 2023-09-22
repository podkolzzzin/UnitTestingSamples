using ObsoleteFilesApp;
using File = ObsoleteFilesApp.File;

namespace UnitTestingSamples.Sample3;

public class ObsoleteFilesDetectorTests
{
  private class DateTimeProviderMock : IDateProvider
  {
    private readonly DateTime _mockDateTime;
    public DateTimeProviderMock(DateTime mockDateTime)
    {
      _mockDateTime = mockDateTime;

    }
    
    public DateTime GetCurrentDateTime() => _mockDateTime;
  }
  
  private class FileSystemProviderMock : IFileSystemProvider
  {
    private readonly IEnumerable<File> _mockFiles;
    public FileSystemProviderMock(IEnumerable<File> mockFiles)
    {
      _mockFiles = mockFiles;
    }

    public IEnumerable<File> EnumerateFiles(string path, string extension) => _mockFiles;
  }
  
  [Fact]
  public void When_NoFilesExist_ShouldReturn_EmptyArray()
  {
    // Arrange
    var mockDateProvider = new DateTimeProviderMock(new (2000, 1, 1));
    var mockFileSystemProvider = new FileSystemProviderMock(Array.Empty<File>());
    var obsoleteFilesDetector = new ObsoleteFilesDetector(mockDateProvider, mockFileSystemProvider);
    
    // Act
    var result = obsoleteFilesDetector.DetectObsoleteFiles("path", "ext", 1);
    
    // Assert
    Assert.Empty(result);
  }
  
  [Fact]
  public void When_FileIsCreatedOnCurrentDate_ShouldReturn_EmptyArray()
  {
    // Arrange
    var currentDate = new DateTime(2020, 1, 1);
    var mockDateProvider = new DateTimeProviderMock(currentDate);
    var mockFileSystemProvider = new FileSystemProviderMock(new[]
    {
      new File("path", currentDate)
    });
    var obsoleteFilesDetector = new ObsoleteFilesDetector(mockDateProvider, mockFileSystemProvider);
    
    // Act
    var result = obsoleteFilesDetector.DetectObsoleteFiles("path", "ext", 1);
    
    // Assert
    Assert.Empty(result);
  }
  
  [Fact]
  public void When_FileIsCreatedOnTenDaysAgo_ShouldReturn_ThisFile()
  {
    // Arrange
    var currentDate = new DateTime(2020, 1, 1);
    var mockDateProvider = new DateTimeProviderMock(currentDate);
    var mockFile = new File("path", currentDate - TimeSpan.FromDays(10));
    var mockFileSystemProvider = new FileSystemProviderMock(new[]
    {
      mockFile 
    });
    var obsoleteFilesDetector = new ObsoleteFilesDetector(mockDateProvider, mockFileSystemProvider);
    
    // Act
    var result = obsoleteFilesDetector.DetectObsoleteFiles("path", "ext", 1);
    
    // Assert
    Assert.Collection(result, 
      x => Assert.Same(mockFile.Path, x));
  }
}