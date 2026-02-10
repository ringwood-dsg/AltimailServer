alter table hm_fetchaccounts add famimerecipientheaders nvarchar(255) not null default 'To,CC,X-RCPT-TO,X-Envelope-To'

insert into hm_settings (settingname, settingstring, settinginteger) values ('TlsOptions', '', 0)

alter table hm_accounts add accountvacationabortspamflagged tinyint not null default 0

alter table hm_accounts add accountforwardabortspamflagged tinyint not null default 0

alter table hm_rule_actions add actionabortspamflagged tinyint not null default 0

update hm_dbversion set value = 5708

