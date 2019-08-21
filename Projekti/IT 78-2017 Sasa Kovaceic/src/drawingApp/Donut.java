package drawingApp;

import java.awt.Color;
import java.awt.Graphics;

public class Donut extends Circle {

	private int innerRadius;
	private Color color;
	private Color colorUnutrasnjostVeliki;
	private Color colorUnutrasnostMali;
	private Color colorIviceMali;
	
	public Donut() {
		
	}
	
	public Donut(Point center, int radius, int innerRadius) {
		super(center, radius);
		this.innerRadius = innerRadius;
	}
	
	public Donut(Point center, int radius, int innerRadius, boolean selected) {
		this(center, radius, innerRadius);
		setSelected(selected);
	}
	
	public void draw(Graphics g) {
		g.setColor(getColor());
		g.drawOval(this.getCenter().getX() - this.radius, getCenter().getY() - getRadius(), this.getRadius()*2, this.getRadius()*2);
		
		g.setColor(getColorUnutrasnjostVeliki());
		g.fillOval(this.getCenter().getX()+1 - this.radius, getCenter().getY()+1 - getRadius(), (this.getRadius()-1)*2, (this.getRadius()-1)*2);
		//super.draw(g);
		
		g.setColor(getColorIviceMali());
		g.drawOval(this.getCenter().getX() - this.innerRadius, this.getCenter().getY() - this.getInnerRadius(), this.getInnerRadius()*2, this.innerRadius*2);
		
		g.setColor(getColorUnutrasnostMali());
		g.fillOval(this.getCenter().getX()+1 - this.innerRadius, this.getCenter().getY()+1 - this.getInnerRadius(), (this.getInnerRadius()-1)*2, (this.innerRadius-1)*2);
		
		if (isSelected()) {
			g.drawRect(getCenter().getX() - 3, getCenter().getY() - 3, 6, 6);
			g.drawRect(getCenter().getX() + getRadius() - 3, getCenter().getY() - 3, 6, 6);
			g.drawRect(getCenter().getX() - getRadius() - 3, getCenter().getY() - 3, 6, 6);
			g.drawRect(getCenter().getX() - 3, getCenter().getY() + getRadius() - 3, 6, 6);
			g.drawRect(getCenter().getX() - 3, getCenter().getY() - getRadius() - 3, 6, 6);
		}
	}
	
	
	
	public boolean contains(int x, int y) {
		double dFromCenter = this.getCenter().distance(x, y);
		return dFromCenter > innerRadius &&
				super.contains(x, y);
	}
	
	public boolean contains(Point p) {
		double dFromCenter = this.getCenter().distance(p.getX(), p.getY());
		return dFromCenter > innerRadius &&
				super.contains(p.getX(), p.getY());
	}
	
	public double area() {
		return super.area() - innerRadius * innerRadius * Math.PI;
	}
	
	public boolean equals(Object obj) {
		if (obj instanceof Donut) {
			Donut d = (Donut) obj;
			if (this.getCenter().equals(d.getCenter()) &&
					this.getRadius() == d.getRadius() &&
					this.innerRadius == d.getInnerRadius()) {
				return true;
			} else {
				return false;
			}
		} else {
			return false;
		}
	}
	
	public Color getColorIviceMali() {
		return colorIviceMali;
	}

	public void setColorIviceMali(Color colorIviceMali) {
		this.colorIviceMali = colorIviceMali;
	}

	public Color getColorUnutrasnjostVeliki() {
		return colorUnutrasnjostVeliki;
	}

	public void setColorUnutrasnjostVeliki(Color colorUnutrasnjostVeliki) {
		this.colorUnutrasnjostVeliki = colorUnutrasnjostVeliki;
	}

	public Color getColorUnutrasnostMali() {
		return colorUnutrasnostMali;
	}

	public void setColorUnutrasnostMali(Color colorUnutrasnostMali) {
		this.colorUnutrasnostMali = colorUnutrasnostMali;
	}

	public Color getColor() {
		return color;
	}

	public void setColor(Color color) {
		this.color = color;
	}
	
	public int getInnerRadius() {
		return innerRadius;
	}
	public void setInnerRadius(int innerRadius) {
		this.innerRadius = innerRadius;
	}
	
	public String toString() {
		return super.toString() + ", inner radius=" + innerRadius ;
	}
	
}
