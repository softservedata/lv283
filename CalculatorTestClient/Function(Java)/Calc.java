package com.softserve.edu;

import javax.jws.WebService;

@WebService(targetNamespace = "http://edu.softserve.com/", endpointInterface = "com.softserve.edu.CalcSEI", portName = "CalcPort", serviceName = "CalcService")
public class Calc implements CalcSEI {

    public String about(String answer) {
        return "Calc Service: " + answer;
    }

    public double add(double arg0, double arg1) {
        return arg0 + arg1;
    }

    public double sub(double arg0, double arg1) {
        return arg0 - arg1;
    }

    public double mul(double arg0, double arg1) {
        return arg0 * arg1;
    }

    public double div(double arg0, double arg1) {
        return arg0 / arg1;
    }

    public double pow(double arg0, double arg1) {
        return Math.exp(arg1 * Math.log(arg0));
    }

    public double sqrt(double arg0) {
        return Math.sqrt(arg0);
    }

    public double sqr(double arg0) {
        return mul(arg0, arg0);
    }

    public long factorial(int number) {
        long result = 1;
        for (int i = 2; i <= number; i++) {
            result = result * i;
        }
        return result;
    }

    public int mod(int arg0, int arg1) {
        return arg0 % arg1;
    }

    public int div(int arg0, int arg1) {
        return arg0 / arg1;
    }

}
