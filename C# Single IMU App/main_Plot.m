clear;clc;close all;
filename = "LoggedData run muscle3.csv";
% filename = "File.csv_CalInertialAndMag.csv";
data = load(filename);
dt = 1/125;
len_num = size(data,1);
time = (1:len_num)'*dt;
%
% % data = data(18500:23000,:);
% % time = time(18500:23000,:);

% data = data(1:7000,:);
% time = time(1:7000,:);

% data = data(8000:15100,:);
% time = time(8000:15100,:);

ticStamp = data(:,1);
AccX = data(:,2);
AccY = data(:,3);
AccZ = data(:,4);
GyrX = data(:,5);
GyrY = data(:,6);
GyrZ = data(:,7);
Muls = data(:,8);
%%
figure(1);
subplot(311);
plot(time,AccX);grid on;
xlabel('$time(s)$','Interpreter','LaTex');
ylabel('$A_x(g)$','Interpreter','LaTex');
subplot(312);
plot(time,AccY);grid on;
xlabel('$time(s)$','Interpreter','LaTex');
ylabel('$A_y(g)$','Interpreter','LaTex');
subplot(313);
plot(time,AccZ);grid on;
xlabel('$time(s)$','Interpreter','LaTex');
ylabel('$A_z(g)$','Interpreter','LaTex');
%%
figure(2);
subplot(311);grid on;
plot(time,GyrX);grid on;
xlabel('$time(s)$','Interpreter','LaTex');
ylabel('$G_x(^\circ/s)$','Interpreter','LaTex');
subplot(312);
plot(time,GyrY);grid on;
xlabel('$time(s)$','Interpreter','LaTex');
ylabel('$G_y(^\circ/s)$','Interpreter','LaTex');
subplot(313);
plot(time,GyrZ);grid on;
xlabel('$time(s)$','Interpreter','LaTex');
ylabel('$G_z(^\circ/s)$','Interpreter','LaTex');
%%
figure(3);
plot(time,Muls);grid on;
xlabel('$time(s)$','Interpreter','LaTex');
ylabel('$Muscle signal(0-1)$','Interpreter','LaTex');
%%
figure(4);
plot(time,Muls,'r',time,GyrZ/200.0,'b');grid on;
xlabel('$time(s)$','Interpreter','LaTex');
legend('Muscle','Gyrz');
% ylabel('$Muscle signal(0-1)$','Interpreter','LaTex');
