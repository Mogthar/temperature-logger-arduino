s=serial('COM4');
fopen(s);

N=100;
figure(1);
xlim([0 N]);
ylim([0,50]);

hold on
fprintf(s,'CHAN 1');
pause(0.1)
for i=0:N
    i
    fprintf(s,'MEAS? 1');
    out=fscanf(s);
    y=str2num(out)
    plot(i,y,'b.');
    pause(0.1)
    
end
hold off

fclose(s)
delete(s)
clear s

