COMPILATION NOTES:

This projects depends on other projects. Some of then the source code or binares have been included into this project. 
In order to give the chance of solving. 

Involve projects and notes:

1. Install the 'ShaderBuildTaks'. This project have source code (for VS2010) as well as binaries. 
$Xhader\ExternalLibraries\Shader Effects BuildTask and Templates <- for binaries ans installation instructions
$Xhader\ExternalSourceCode\ShaderBuildTask <- To compile the source code.
If you want to compile the project, then you're more likely to install the DirectX SDK in order to make it compile properly. 
Once it's compiled, you can use the generated installer to set up this build task. On the other hand, you can go
directly to the binaries 
To checkout more about this project go to http://wpf.codeplex.com/releases/view/14962


2. Silverlight toolkit
Silverlight project uses Silverlight toolkit. To keep simple things the Binaries has been inlcuded at
$Xhader\ExternalLibraries\Silverlight\Silverlight Toolkit

You might need perform some security settings bacause these are downloaded DLLS. Try to compile if this does not 
work then take a look at http://go.microsoft.com/fwlink/?LinkId=179545 if the following error appears:

"Error		Could not load the assembly xhader\ExternalLibraries\Silverlight\Silverlight Toolkit\April 2010 Silverlight Toolkit\Bin\System.Windows.Controls.DataVisualization.Toolkit.dll. This assembly may have been downloaded from the Web.  If an assembly has been downloaded from the Web, it is flagged by Windows as being a Web file, even if it resides on the local computer. This may prevent it from being used in your project. You can change this designation by changing the file properties. Only unblock assemblies that you trust. See http://go.microsoft.com/fwlink/?LinkId=179545 for more information.	SLEffectHarness"

To checkout more about this project go to http://silverlight.codeplex.com/