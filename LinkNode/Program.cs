// See https://aka.ms/new-console-template for more information
using LinkNode;
// 生成一个随机的 Guid
Guid randomGuid = Guid.NewGuid();

// 将 Guid 转换为字符串并输出
string guidString = randomGuid.ToString();
Console.WriteLine("Hello, World!");
var my = new MyLinkedList();
my.addAtTail(1);
my.addAtTail(2);
//my.addAtTail(3);
//my.addAtTail(4);
//my.addAtTail(5);

//my.Print(my.Head.next);
var new_head=my.RemoveNthFromEnd(my.Head.next,1);
my.Print(new_head);

Console.ReadLine();


