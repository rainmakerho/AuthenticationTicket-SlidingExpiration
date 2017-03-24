# Forms AuthenticationTicket SlidingExpiration 過期問題

最近同仁分享一個 Form Authentication Ticket 過期的問題(為什麼我的 APS.Net Form Authentication 在 timeout 時間還沒到前就失效了)。

如果 timeout 時間設定為 20 分鐘，而 Ticket 是 1:00:00 產生的，到期時間是 1:20:00。

如果設定 SlidingExpiration ， 到期的時間會在每次回 Server 就更新嗎?

Timeout 時間跟你想的不一樣嗎?

我們可以看 MSDN 上的說明「FormsAuthentication.SlidingExpiration」，

如果提出要求，而且一半以上的逾時間隔已經經過滑動期限，重設為有效的驗證 cookie 的到期時間。
