package com.perples.recosample;

public class Trilateration {

    public Point2D getTrilateration(Point2D pos1, Point2D pos2, Point2D pos3){
        double s = (Math.pow(pos3.x, 2.) - Math.pow(pos2.x, 2.) +
                Math.pow(pos3.y, 2.) - Math.pow(pos2.y, 2.) +
                Math.pow(pos2.distance, 2.) - Math.pow(pos3.distance, 2.))/2.0;

        double t = (Math.pow(pos1.x, 2.) - Math.pow(pos2.x, 2.) +
                Math.pow(pos1.y, 2.) - Math.pow(pos2.y, 2.) +
                Math.pow(pos2.distance, 2.) - Math.pow(pos1.distance, 2.))/ 2.0;

        double y = ((t*(pos2.x - pos3.x))-(s*(pos2.x - pos1.x))) / (((pos1.y - pos2.y) *
                (pos2.x - pos3.x)) - ((pos3.y - pos2.y)*(pos2.x - pos1.x)));

        double x = ((y * (pos1.y - pos2.y))-t)/(pos2.x - pos1.x);

        return  new Point2D(x, y, 0);
    }


}
