function [f,Y,NFFT]=LG_FFT(xn,Fs)
% function [f,Y]=LG_FFT(xn,Fs)
% xn: raw data
% Fs   : Sampling frequency
% f : Hz
% Y : magnitude
T = 1/Fs;                     % Sample time
L = length(xn);                     % Length of signal

NFFT = 2^nextpow2(L); % Next power of 2 from length of y
Y = fft(xn,NFFT)/L;
f = Fs/2*linspace(0,1,NFFT/2+1);

% Plot single-sided amplitude spectrum.
semilogx(f,2* abs(Y(1:NFFT/2+1)) );
grid on;
% semilogx(f,20*log10( 2*abs(Y(1:NFFT/2+1))) ) 
title('Single-Sided Amplitude Spectrum of y(t)')
xlabel('Frequency (Hz)')
ylabel('|Y(f)|')
end