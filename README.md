Altimail Server/hMailServer 6.x
===========

Altimail Server is an open-source free-to-use email server for Microsoft Windows, built as the modern and actively developed continuation of the original 
[hMailServer](https://www.hmailserver.com/). Altimail Server is designed to be lightweight, standards-compliant, and easy to integrate into your self-hosted 
infrastructure.

> [!IMPORTANT]
> This project aims to pick up where hMailServer left off, continuing development toward what is effectively **hMailServer 6.0**, under a new name and renewed 
> vision for modern Windows systems. In aiming to keep up with modern standards, **legacy support for older Windows versions and subsequent database engines will 
> be discontinued in each new subsequent release**. See "Transitioning to Altimail Server" for more details.

> [!TIP]
> If your environment depends on legacy compatibility, you are encouraged to continue using your current hMailServer setup.

## ⚡ What is Altimail Server?

Altimail Server is an open-source free-to-use email server for Microsoft Windows that supports the following features out-of-the-box:

- SMTP, POP3, and IMAP
- SSL/TLS and STARTTLS encryption
- Built-in anti-spam and anti-virus support
- ClamAV and SpamAssassin (local and remote) support
- Scripting engine for custom logic (using VBScript)
- Domain and user management
- SQL-database support (Microsoft SQL Server, MySQL, MariaDB, and PostgreSQL)
- Web-based administration interface (`php` currently)
- Active development roadmap toward Altimail Server/hMailServer 6 and beyond

It's an ideal solution for self-hosters, hobbyists, businesses, and developers who need full control over their email infrastructure on Windows platforms.

## 🤝 Relationship to hMailServer

Altimail Server is a fork of [hMailServer](https://github.com/hmailserver/hmailserver) via an 
[intermediate community-maintained version](https://github.com/RvdHout/hmailserver). Development on the original project has officially ended, and this fork 
aims to:

- Consolidate scattered community fixes and patches; 
- Modernise the codebase and build tools; 
- Maintain compatibility with newest Windows environments; and 
- Provide long-term, open-source stewardship of the project. 

> [!WARNING]
> While Altimail Server builds on the legacy of hMailServer, **it is diverging structurally and architecturally** - and will not remain backward-compatible in 
> all areas going forward.

## 🚀 Transitioning to Altimail Server

Altimail Server is a modern reimagining of hMailServer - designed to drop legacy baggage and move forward with today's Windows ecosystem. Altimail Server can function as a *drop-in replacement* for most existing hMailServer deployments, but there are some important 
structural changes to be aware of.

> [!WARNING]
> Altimail Server **is not binary compatible** with hMailServer.
> 
> 32-bit support **is being deprecated** and should **no longer** be relied upon.

Altimail Server introduces the following **breaking** changes:

1. Namespace changes.
2. COM object identifier- and signature changes.
3. Support for 32-bit **is being deprecated** (aka *x86*).
4. Future API expansions and changes.

As a result, existing third-party integrations, custom scripts, and programs that rely on hMailServer's original structure may require modification to function correctly with Altimail Server. 

### Coexistence with hMailServer
Altimail Server's updated application and COM signatures allows side-by-side installation of hMailServer and Altimail Server. This provides a convenient **migration path** with the ability to revert quickly during testing or evaluation.

> [!NOTE]
> Even though Altimail Server and hMailServer can co-exist, they **cannot be running at the same time**!

### What Remains Compatible?
While internal structures have evolved, Altimail Server **maintains full compatibility with hMailServer's data directory and database schema**. This allows your existing configuration, domains, user accounts, and messages to be used without any 
changes apart from any required database upgrades. 

---

## 💾 System Requirements

- **Microsoft Windows Server 2008 R2+SP1/Windows 7+SP1 or later**
- **.NET Framework 4.8**
- A **supported database engine**, either local or remote

Altimail Server currently supports the following database engines:

- Microsoft SQL Server
- PostgreSQL
- MySQL 5.7.9 or later (❓ see "Database Support: MySQL vs MariaDB" below) 
- MariaDB 10.5.29 GA or later 

### ⚠️ Support Policy for Windows and Database Versions

To deliver a secure and future-ready email server, **Altimail Server drops support for outdated Windows operating systems and legacy database engines**. 

#### Why We're Making This Change

1. **Security First**
   Older operating systems no longer receiving security updates from Microsoft are **inherently vulnerable**, and relying on them for production email infrastructure is risky at best. Without 
   guaranteed security patches - or assurance that users will apply them in time - we cannot confidently support these environments. 
2. **Access to Modern Features** 
   By focusing on supported Windows versions and modern databases, Altimail Server can **take full advantage of newer APIs**, **security models**, **performance improvements**, and **developer tooling** - 
   all of which contribute to a more stable and feature-rich mail server.
   
#### What This Means:

- **Altimail Server only runs on versions of Windows that are currently under Microsoft's mainstream or extended support**.
- Older database engines that lack current support or security updates may not be compatible. 
- If your infrastructure _depends on legacy platforms_, you can continue using your current hMailServer setup - but Altimail Server is designed for those ready to move forward.

By narrowing our support scope, we make Altimail Server **safer**, **faster**, and **better equipped for the future** of Windows-based mail services.

---

## Database Support: MySQL vs MariaDB

Altimail Server supports both **MySQL** and **MariaDB** databases, but there are important differences in how that support is delivered:

#### ✅ MariaDB - Native Support 

Altimail Server now provides **built-in support for MariaDB** through the **MariaDB C Connector**, which is compiled and distributed as part of the Altimail Server application. This ensures seamless integration, 
improved performance, and avoids external licensing issues. No additional setup is required - it's ready out of the box.

#### ⚠️ MySQL - User-Supplied Connector Required 

While MySQL databases are still supported, Altimail Server **does not ship with the MySQL connector**. This is due to license incompatibilities: the MySQL Connector/C is licensed under GPLv2, which is not 
compatible with Altimail Server's AGPLv3 license. If you wish to use MySQL as your database of choice, you will need to provide this connector (also known as `libmysql.dll`) when configuring your 
database.

> [!WARNING]
> Altimail Server is built for x64 architectures. When supplying the `libmysql.dll` connector file, please ensure that you supply the **64-bit/x64/amd64** version!

### TL;DR 

- ✅ **MariaDB**: Supported natively, no extra steps.
- ⚠️ **MySQL**: Supported, but you must provide the 64-bit connector due to license constraints.

---

## 📦 Releases

Compiled binaries and installers will be made available on the [Altimail Server website](https://www.altimailserver.org).

---

## ⚒️ Building Altimail Server
### A word on branches
#### Using the `master` branch
This is the active development branch and contains the newest code. New features and bug fixes are introduced here.

> [!CAUTION]
> The code in the `master` branch is typically **not production ready** and shouldn't be used for that purpose.

#### Using a version branch `x.y.z`
These branches correspond to their equivalent releases, i.e. it contains all the code up until that release was compiled and uploaded to the Altimail Server's website. **_Only bug- and critical issue fixes_** are 
permitted in these branches. 

> [!WARNING]
> Version branches will remain active until the next version release is made public. From that point support for that particular branch will end and no further fixes will be allowed.

### Environment Configuration
In order to build and contribute to Altimail Server's code base, you will need:

- An installed version of [**Altimail Server 6.x**](https://www.altimailserver.org) (configured with an appropriate database); 
- [**Microsoft Visual Studio 2022**](https://visualstudio.microsoft.com/vs/) _(see notes below)_
- [**InnoSetup 6.3.4**](https://jrsoftware.org/isinfo.php) or later
- [**Strawberry Perl 64-bit**](https://strawberryperl.com/) or [**Perl ActiveState ActivePerl Community Edition**](https://www.activestate.com/activeperl/downloads)
- [**OpenSSL 3.0.16 LTS**](https://openssl-library.org/source/) _(see notes below)_
- [**Boost 1.84.0**](https://www.boost.org/releases/1.84.0/) _(see notes below)_

> [!CAUTION]
> You should **not be** compiling Altimail Server on a computer that already runs a production version of Altimail Server. When compiling Altimail Server, the compilation will stop any already running version of 
Altimail Server and register the compiled version as the Altimail Server version on the machine!

#### Visual Studio 2022 Configuration
Run the Visual Studio installer and ensure that the following **workloads** are selected:

- .NET Desktop Development
- Desktop Development with C++

Next, make sure the following **individual components** are selected:

- .NET Framework 4.8 SDK
- .NET Framework 4.8 targeting pack
- C++ ATL for latest v143 build tools (x86 & x64) 
- Windows 10 SDK (10.0.26100.0)

#### Environment Variable
Altimail Server requires a system environment variable to resolve some of its assemblies during build. Create a **system environment variable** named `AltimailServerLibs` and set its value to the path 
where you will store your extra assemblies, such as `C:\Dev\AltimailServerLibs`. From this point forward we will refer to this location as `AltimailServerLibs`.

_If you happened to forget to follow this step, and Visual Studio is open, make sure you **restart** Visual Studio to make the new environment variable visible._

#### OpenSSL Setup
1. Download [OpenSSL 3.0.16 LTS](https://openssl-library.org/source/).
2. Extract it to `AltimailServerLibs`. You should now have `%AltimailServerLibs%\openssl-3.0.16` which itself contains a bunch of files. *Ensure you don't extract to `%AltimailServerLibs%\openssl-3.0.16\openssl-3.0.16`!*
3. Start a **x64 Native Tools Command Prompt for VS2022** in **Administrator** mode.
4. Change your current directory to `%AltimailServerLibs%\openssl-3.0.16`, e.g. `cd C:\Dev\AltimailServerLibs\openssl-3.0.16`.
5. Run the following commands, one after the other:

   <pre>
   SET CFLAGS=-DOPENSSL_TLS_SECURITY_LEVEL=0
   Perl Configure no-asm VC-WIN64A --prefix=%cd%\out64 --openssldir=%cd%\out64 -D_WIN32_WINNT=0x603 --api=1.1.1 no-deprecated
   nmake clean   
   nmake install_sw
   </pre>

#### Boost Setup
#### Option A: Precompiled Binaries
Contrary to popular belief, you can use the precompiled binaries directly from the Boost website. By ensuring the Altimail Server codebase uses the newest standards, and follows Boost' usage of these standards, along with those of OpenSSL, we can make Altimail Server work with Boost' precompiled binaries. This is how Altimail Server has been configured.

1. Download the [Boost 1.84.0 Windows Binary](https://www.boost.org/), e.g. `boost_1_84_0-msvc-14.3-64.exe`. 
2. Run the installer and make sure you install it to `%AltimailServerLibs%\boost_1_84_0`. Again, **not** `%AltimailServerLibs%\boost_1_84_0\boost_1_84_0`!

#### Option B: Build it yourself
If you're still old school and want to build Boost yourself, you are free to do so. This is what you need to do:

> [!IMPORTANT]
> After you have built Boost, please ensure that you set your linker to use `%AltimailServerLibs%\boost_1_84_0\stage\lib` and not `%AltimailServerLibs%\boost_1_84_0\libs`.

1. Download [Boost 1.84.0](https://www.boost.org/).
2. Extract it to `%AltimailServerLibs%`. You should now have `%AltimailServerLibs%\boost_1_84_0` which itself contains a bunch of files. *Ensure you don't extract to `%AltimailServerLibs%\boost_1_84_0\boost_1_84_0`!*
3. Start a **x64 Native Tools Command Prompt for VS2022** in **Administrator** mode.
4. Change your current directory to `%AltimailServerLibs%\boost_1_84_0`, e.g. `cd C:\Dev\AltimailServerLibs\boost_1_84_0`.
5. Run the following commands, one after the other:

> [!TIP]
> Change the `-j 4` parameter to how many ever cores you might have on your build machine. For example, if your CPU has 6 cores, set this to `-j 6`.

   <pre>
   bootstrap
   b2 debug release threading=multi --build-type=complete --toolset=msvc address-model=64 stage --build-dir=out64 -j 4 define=BOOST_USE_WINAPI_VERSION=0x0601
   </pre>

### 🧑‍💻 Building Altimail Server

1. Ensure you have followed the instructions as set out above. You **cannot proceed** if you haven't done any of it.
2. Visual Studio 2022 must be in **Administrator** mode.
3. Open `altimailserver\source\Server\AltimailServer\AltimailServer.sln` and compile it.
   This builds the server part (`AltimailServer.exe`).
4. Open `altimailserver\source\Tools\AltimailServerTools.sln` and compile it.
   This builds the accompanying tools like the server administrator, data directory synchroniser and so forth.
5. Using InnoSetup, open `altimailserver\installation\AltimailSetup-amd64.iss`. 
   This builds the installer.

#### Running in Debug Mode 

If you want to run Altimail Server in debug mode using Visual Studio, add the command argument `/debug`. This can be set via Project properties -> Configuration Properties -> Debugging.

### ❗Running Tests

The Altimail Server source code contains a number of automated tests which exercises the basic functionality. **When adding new features** or **fixing bugs**, corresponding tests 
**must be added**. Altimail Server uses NUNIT tests. They can be executed in Visual Studio like so:

> [!CAUTION]
> When running tests, your local Altimail Server installation will be updated with test accounts. Existing domains and accounts are deleted. Each test prepares the server configuration in different 
ways. **Please do not run these automated tests on a production version of Altimail Server!**

1. Make sure you've built/compiled Altimail Server. The tests **relies upon a built version of Altimail Server**.
2. Using Visual Studio, open the test solution `altimailserver\tests\AltimailServerTests.sln`.
3. Open the Test Explorer, if it is not yet open. You can open it via the VIEW menu in Visual Studio, then selecting Test Explorer.
4. Available tests should appear under `RegressionTests`. 
5. Right-click the desired test or test category and choose `Run` from the context menu.
   Alternatively, if you want to run a test from a source code file, simply right-click anywhere in the file and select `Run Test(s)` to run it.
   
## 📦 Releasing Altimail Server

If you find no serious issues or concerns, you can proceed with releasing your own build of Altimail Server by following these steps:

1. ❗ **Run all integration tests on supported versions of Windows and supported databases.**. This ensures compatibility.
2. ⚠️ **Run all server stress tests.** These tests are important, so please make sure you do this.
3. 🚀 Run all integration tests with **Gflags enabled** to check for memory issues:
- Open a new Terminal or Command window with **Administrator** privileges.
- Change your current directory to where Altimail Server was built, e.g. `altimailserver\source\Server\AltimailServer\x64\Release\AltimailServer.exe`.
- Now run `gflags /p /enable AltimailServer.exe`.
4. Wait for **at least 500 downloads** before moving your build from `beta` to `release`.
5. Run for **at least 1 month** in production for eligibility for inclusion as an official release on _altimailserver.org_.

## 🧑‍🤝‍🧑 Community & Contributions

We welcome, and encourage, all contributions - whether it's code, documentation, testing, or ideas. You can: 

- Join discussions in Issues.
- Submit pull requests.
- Help with documentation or translations.
- Report bugs or suggest features.

We encourage **respectful**, **constructive engagement** in line with our Code of Conduct.

## 📃 License

Altimail Server is licensed under the GNU AGPLv3, in line with the original hMailServer license terms.

## 🙏 Credits

- [**hMailServer**](https://github.com/hmailserver/hmailserver) by Martin Knafve - original creator and long-time maintainer.
- [**hMailServer 5.7.0-Mod**](https://github.com/RvdHout/hmailserver) by Ruud van den Hout - forming the base and core of Altimail Server.
- Community contributors from the hMailServer forums and GitHub forks. 
- Everyone supporting modern open-source email infrastructure.