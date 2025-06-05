#pragma once
/*VERSION README (IMPORTANT):

We use semantic versioning. The components are [Major].[Minor].[Revision].[Build] where
[Major] = New and BREAKING changes.
[Minor] = New features not vital to the operation including any bug fixes. Could be new features tested without any massive issues.
[Revision] = Used AFTER a release was published. Incremental build number to indicate the after-release build number.
[Build] = YYMM.BUILD_NO where BUILD_NO is incremental for each build and independent of [Revision].
e.g. 6.1.2.2506 => Major = 6, Minor = 1, Revision = 2 (2nd build after release), Build = 2506 (June 2025)

*/

#define ALTIMAILSERVER_VERSION "6.0.0" 
#define ALTIMAILSERVER_VERSION_NUMERIC 6,0,0,2506
#define ALTIMAILSERVER_BUILD "2506.1" /*YYMM.BUILD_NO where BUILD_NO is always incremented with each build/release.*/
/*
[list=1]
[*]Added: Equalize Return-Path format used within hMailServer, eg : Return-Path : <return-route-addr> (always use angle brackets)
[*]Added: TLS server cipher preference support and support for prioritizing ChaCha20Poly1305 [url=https://github.com/hmailserver/hmailserver/pull/379]pull 379[/url]
[*]Added: DKIM signature for domain aliases [url=https://github.com/hmailserver/hmailserver/pull/383]pull 383[/url]
[*]Added: Received-SPF: diagnostic header controlled with INI setting "AddReceivedSPFHeader" (skip for authenticated client connections or localhost!)
[*]Added: (envelope-from <user@domain.com>), for <user@domain.com> to Received: header (if single recipient!)
[*]Fix: All 5xx errors are permanent errors and should be treated as such, eg: contributing to invalid commands counter
[*]Fix: hMailServer AUTH PLAIN in SMTP fails when authzid is supplied
[*]Fix: Minor bugfix where the Received-SPF diagnostic header gave incomplete or inaccurate results
[*]Fix: Minor bugfix where the Received-SPF diagnostic header gave inaccurate results when receiving mail through a (trusted/internal) relay
[*]Added: IPv6 Support for BLCheck [url=https://github.com/hmailserver/hmailserver/pull/487]pull 487[/url]
[*]Experimental: improved SA winsock 2 error fix, ignore all boost::asio::error::eof errors which probably are related to IMAP FETCH HM5136 errors
[*]Fix: hMailServer AUTHENTICATE PLAIN in IMAP exposed account password in log, added OnClientLogon() event trigger within AUTHENTICATE PLAIN routine
[*]Fix: Improved AUTH PLAIN base64 encoded username and password masking, retain client command format for troubleshooting purposes
[*]Fix: SURBL modification to check full URI's and trimmed down URI's
[*]Fix: Strip possible spaces in DKIM 'p' parameter, there shouldn't be any spaces but it's a common mistake so we act lenient and strip any spaces found
[*]Fix: Apple IOS related HM5136, HM4208 and subsequent "OutOfMemoryHandler" errors [url=https://github.com/hmailserver/hmailserver/issues/475]issue 475[/url], credits to Rado https://github.com/hunterius-prime
[*]F̶i̶x̶:̶ ̶I̶M̶A̶P̶ ̶F̶E̶T̶C̶H̶ ̶o̶n̶ ̶m̶e̶s̶s̶a̶g̶e̶/̶r̶f̶c̶8̶2̶2̶ ̶M̶I̶M̶E̶ ̶p̶a̶r̶t̶ [url=https://github.com/hmailserver/hmailserver/issues/459]i̶s̶s̶u̶e̶ ̶4̶5̶9̶[/url],̶ ̶c̶r̶e̶d̶i̶t̶s̶ ̶t̶o̶ ̶R̶a̶d̶o̶ ̶h̶t̶t̶p̶s̶:̶/̶/̶g̶i̶t̶h̶u̶b̶.̶c̶o̶m̶/̶h̶u̶n̶t̶e̶r̶i̶u̶s̶-̶p̶r̶i̶m̶e̶
[*]Added: Google Feedback Loop header Feedback-ID in DKIM signing [url=https://github.com/hmailserver/hmailserver/pull/492]pull 492[/url]
[*]Fix: Better log on forward failures, https://github.com/maxsnts/hmailserver/commit/7e285c3a1abe11ad4605aa71bd64176989c473a1
[*]Fix: Spam scoring/marking/count inconsistencies
[*]Added: eMessageFlag Spam = 128
[*]Added: Abort forwarding if original message is marked as Spam
[*]Added: Abort vacationmessage if original message is marked as Spam
[*]Added: Abort autoreply/forwarding through rules if original message is marked as Spam
[*]Undo: .17
[*]Fix: IMAP FETCH on message/rfc822 MIME part (roundcube specific when messages are forwarded as attachment)
[*]5.8.0/2025-06-03: Codebase update for platform toolset v143 and c++ 17. Update Boost to 1.84.0, OpenSSL to 3.0.16 [LTS].
[/list]
*/