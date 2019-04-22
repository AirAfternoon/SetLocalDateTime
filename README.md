# SetLocalDateTime

This code only for learning. Can not use in the production
When crossing the end of year, it set to the timezone what is set in server.
The Field in the code may not same name in other version of assembly.
So, you can juse use GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static) to find true names of fields in your assembly.

此代码仅供学习，不能用在生产环境，有坑。跨年后时区会自动设置回服务器时区。
反射字段名字在其他版本里面可能会不一样，可用GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static)来找出版本中相对应名字。
