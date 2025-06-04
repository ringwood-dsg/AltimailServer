hMailServer 5.8.0 (Build 2506.15)
===========

hMailServer is an open source email server for Microsoft Windows. This page describes how to compile and run hMailServer. 

> [!CAUTION]
> **Active development on hMailServer has officially ended.**
> 
> New development will be continued under the [**Altimail Server**](https://www.altimailserver.org) brand. The purpose of this branch is to provide a stable build of hMailServer to existing users without having to upgrade to **Altimail Server**. This branch
> has been forked from [RvdHout/hmailserver:5.7.0-Mod](https://github.com/RvdHout/hmailserver) and the codebase upgraded to C++ 17, Platform Tools v143, Boost 1.84.0, OpenSSL 3.0.16 (LTS), and PostgreSQL connector 15.12. Accompanying tools 
have been upgraded to .NET Framework 4.8.

For more information on legacy hMailServer, please visit http://www.hmailserver.com. For information on **Altimail Server**, please visit https://www.altimailserver.org.

Building hMailServer
====================
## Environment Setup

   * An installed version of hMailServer 5.8.0 (configured with a database)
   * Visual Studio 2022
   * InnoSetup 6.4.3 or later
   * [Strawberry Perl 64-bit](https://www.strawberryperl.com)
   * A suitable database engine (MSSQL, MySQL, MariaDB, PostgreSQL) if you want to test/use external databases.
   * Boost 1.84.0 pre-compiled binaries for Windows (`boost_1_84_0-msvc-14.3-64.exe`)
   * OpenSSL 3.0.16 [LTS] source
   
**NOTE**

You should not be compiling hMailServer on a computer which already runs a production version of hMailServer. When compiling hMailServer, the compilation will stop any already running version of hMailServer, and will register the compiled version as the hMailServer version on the machine (configuring the Windows service). This means that if you are running a production version of hMailServer on the machine, this version will stop running if you compile hMailServer. If this happens, the easiest path is to reinstall the production version.

### Installing Visual Studio 2022

1. Download [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) and launch the installation.
2. Select the following _Workloads_
  * .NET desktop development
  * Desktop development with C++
3. Select the following _Individual Components_
  * C++ ATL for latest v143 build tools (x86 & x64)
  * Windows 10 SDK (10.0.20348.0)

#### 3rd party libraries

Some 3rd party libraries which hMailServer relies on are large and updated frequently. Rather than including these large libraries into the hMailServer git repository, they have to be downloaded and built, currently manually. When you build hMailServer, Visual Studio will use a system environment variable, named `hMailServerLibs`, to locate these libraries.

Create a **system environment variable** named `hMailServerLibs` pointing at a folder where you will store hMailServer libraries, such as `C:\Dev\hMailLibs`.

### Building OpenSSL
1. Download OpenSSL 3.0.16 from [http://www.openssl.org/source/](https://openssl-library.org/source/) and put it into `%hMailServerLibs%\<OpenSSL-Version>`.
   You should now have a folder named `%hMailServerLibs%\<OpenSSL-version>`, for example `C:\Dev\hMailLibs\openssl-3.0.16`
2. Start a **x64 Native Tools Command Prompt for VS2022** in **Administrator** mode.
3. Change dir to `%hMailServerLibs%\<OpenSSL-version>`.
3. Run the following commands:

   <pre>
   SET CFLAGS=-DOPENSSL_TLS_SECURITY_LEVEL=0
   Perl Configure no-asm VC-WIN64A --prefix=%cd%\out64 --openssldir=%cd%\out64 -D_WIN32_WINNT=0x600 --api=1.1.1 no-deprecated
   nmake clean   
   nmake install_sw
   </pre>

### Boost Setup
#### Precompiled Binaries
This branch of hMailServer has been configured and built with precompiled binaries.

1. Download the precompiled Windows binaries for [Boost 1.84.0](https://www.boost.org/).
2. Run the installer and specify the directory where the Boost assemblies should be installed to. This is typically your `%hMailServerLibs%\boost_1_84_0` directory. 

#### Building Boost
If you do not want to use the precompiled binaries and favour building them yourself, please follow these instructions carefully:

1. Download Boost 1.84.0 from http://www.boost.org/ and put it into `%hMailServerLibs%\<Boost-Version>`.  
   You should now have a folder named `%hMailServerLibs%\<Boost-Version>`, for example `C:\Dev\hMailLibs\boost_1_84_0`
2. Start a **x64 Native Tools Command Prompt for VS2022** in **Administrator** mode, if not open already.
3. Change dir to `%hMailServerLibs%\<Boost-Version>`.
4. Run the following commands:
 
   NOTE: Change the -j parameter from 4 to the number of cores on your computer. The parameter specifies the number of parallel compilations will be done.

   <pre>
   bootstrap
   b2 debug release threading=multi --build-type=complete --toolset=msvc address-model=64 stage --build-dir=out64 -j 4 define=BOOST_USE_WINAPI_VERSION=0x0600
   </pre>

5. Configure the Linker for both `.../source/Server/hMailServer` and `.../source/Server/hMailServer.Minidump` to use `boost_1_84_0\stage\lib` instead of `boost_1_84_0\libs`.

### Building hMailServer
Visual Studio 2022 must be started with _Run as Administrator_.

1. Download the source code from this Git repository and branch.
2. Compile the solution `hmailserver\source\Server\hMailServer\hMailServer.sln`.
   This will build the hMailServer server-part (`hMailServer.exe`)
3. Compile the solution `hmailserver\source\Tools\hMailServer Tools.sln`.
   This will build hMailServer related tools, such as hMailServer Administrator and hMailServer DB Setup.
4. Compile `hmailserver\installation\hMailServer64.iss` (using InnoSetup)
   This will build the hMailServer installation program.

## Running in Debug
If you want to run hMailServer in debug mode in Visual Studio, add the command argument `/debug`. You find this setting in the Project properties, under Configuration Properties -> Debugging.

## Running tests
hMailServer source code contains a number of automated tests which excercises the basic functionality. When adding new features or fixing bugs, corresponding tests should be added. hMailServer tests are implemented using NUnit. To run them in Visual Studio, follow these steps:

**NOTE**: When running tests, your local hMailServer installation will be updated with test accounts. Existing domains and accounts are deleted. Each tests prepares the server configuration in different ways. In other words, **do not run the automated tests in an environment where you need to preserve hMailServer data**.

1. Make sure `hMailServer.exe` is built and can be run. The tests will launch the service.
2. Open the test solution, `\hmailserver\test\hMailServer Tests.sln`
3. In Visual Studio, select Test Explorer from the View-menu. 
4. Locate a test to run under "RegressionTests"
5. Right-click on a test or test category and select "Run".

You can also navigate to the source code for a test, right-click anywhere and select "Run Test(s)" to run it.

# Releasing hMailServer
Without finding any serious issues:

1. Run all integration tests on supported versions of Windows and the different supported databases. 
2. Run all server stress tests
3. Enable Gflags (`gflags /p /enable hmailserver.exe`) and run all integration tests to check for memory issues
4. Wait for at least 500 downloads of the beta version
