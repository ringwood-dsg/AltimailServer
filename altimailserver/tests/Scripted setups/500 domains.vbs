dim app
set app = createObject("AltimailServer.Application")

call app.Authenticate("Administrator", "testar")

dim obDomains
set obDomains = app.Domains

dim i 
for i = 1 to 500
	set newDomain = obDomains.Add

	sDomainName = "test" + CStr(i) + ".com"

	newDomain.Name = sDomainName 
	newDomain.Save
	
next