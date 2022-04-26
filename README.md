## 模拟电子线路实验作品自动测试评分工具 (Auto Scoring Tool for Analog Electronic Circuit Works)

该程序可用于模拟电子线路实验作品的自动测试（典型的例子是全国大学生电子设计竞赛综合测试赛题）。
The program can be used to automatically test analog electronic circuit experimental works (typical example is the NUEDC comprehensive test).

测试过程依赖一台带有以太网接口并支持SCPI指令接口的多功能示波器（典型的例子是固纬MDO-2000ES系列）。
The test relied on a multifunctional oscilloscope with an Ethernet interface and support the SCPI instructions (typical example is the GwInstek MDO-2000ES series).

开始测试前需要：
Before test:
* 将作品和示波器连接；
Connect the work to the oscilloscope;
* 设定好示波器的IP地址、端口号并打开其Socket服务器；
Set the IP address and port of the oscilloscope and open its Socket server;
* 保证计算机和示波器在同一网段内（可以用ping命令测试）。
Make sure that the computer and the oscilloscope are in the same network (can be tested with the ping command).

将测试项目信息填写到程序界面之中，程序便可依据填写的测试项目逐条自动完成测试并根据填写的评分公式评分。
Fill in the measurement item informations in the program gui, and the program can automatically complete the measurements according to the filled informations and score according to the score formula filled in.

如果待测试的端口多于示波器的模拟输入端口，还可另接程控通道扩展板。
If there are more ports to be measured than the analog input ports of the oscilloscope, an additional program-controlled channel expansion board can be used.

具体请参考PDF文档《模拟电子线路自动测试程序使用和开发》。
For details, please refer to the PDF document 《模拟电子线路自动测试程序使用和开发》 (Sorry for no English version yet).
