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
%%
Gyroscope = [GyrZ,GyrX,GyrY];
Accelerometer = [AccZ,AccX,AccY];
% Gyroscope = [GyrX,GyrY,GyrZ];
% Accelerometer = [AccX,AccY,AccZ];
Magnetometer = 0*Gyroscope;
save('matlab.mat','time','Gyroscope','Accelerometer','Magnetometer');