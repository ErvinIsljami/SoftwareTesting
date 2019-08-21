package stackApp;

import java.awt.BorderLayout;
import java.awt.EventQueue;
import java.awt.FlowLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.border.EmptyBorder;
import javax.swing.*;
import java.awt.Color;

public class StackApp extends JFrame {

	private JPanel contentPane;
	private DefaultListModel<Rectangle> dlm = new DefaultListModel<Rectangle>();
	
	//
	
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					StackApp frame = new StackApp();
					frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}
	
	//
	
	public StackApp() {
		setTitle("Stack");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100,200,450,200);
		
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		contentPane.setLayout(new BorderLayout(0, 0));
		setContentPane(contentPane);
		
		JPanel pnlN = new JPanel();
		contentPane.add(pnlN, BorderLayout.NORTH);
		
		JLabel lblRectangle = new JLabel("Rectangle list:");
		pnlN.add(lblRectangle);
		
		JPanel pnlW = new JPanel();
		FlowLayout fl_pnlW = (FlowLayout) pnlW.getLayout();
		contentPane.add(pnlW, BorderLayout.WEST);
		
		JButton btnAdd = new JButton("Add");
		btnAdd.setForeground(Color.BLACK);
		btnAdd.setBackground(Color.LIGHT_GRAY);
		btnAdd.addActionListener(new ActionListener() {
			
			public void actionPerformed(ActionEvent e) {
				DlgAdd d = new DlgAdd();
				d.setVisible(true);
				if(d.isOK()) {
					try {
						Point p = new Point(Integer.parseInt(d.getTxtX().getText()),Integer.parseInt(d.getTxtY().getText()));
						Rectangle r = new Rectangle(p,Integer.parseInt(d.getTxtVisina().getText()),Integer.parseInt(d.getTxtSirina().getText()));
						dlm.add(0,r);
					} catch(NumberFormatException ex) { //za svaki slucaj ako nekako ipak uspe slova da unese
						JOptionPane.showMessageDialog(null, "Only numbers allowed!","Error", JOptionPane.WARNING_MESSAGE);
					}
				}
				d.getTxtX().setText("");
				d.getTxtY().setText("");
				d.getTxtSirina().setText("");
				d.getTxtVisina().setText("");
			}
		});
		
		pnlW.add(btnAdd);
		
		JButton btnDelete = new JButton("Delete");
		btnDelete.setBackground(Color.LIGHT_GRAY);
		btnDelete.setForeground(Color.BLACK);
		
		btnDelete.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				DlgAdd d = new DlgAdd();
				try {
				d.getBtnOk().setVisible(true); //isti dijalog kao za dodavanje, moze se realizovati i sa 2 razlicita
				d.getBtnDodaj().setVisible(false);
				d.getBtnOdustani().setVisible(false);
				d.getTxtX().setText(Integer.toString(dlm.get(0).getUpperLeftPoint().getX()));
				d.getTxtY().setText(Integer.toString(dlm.get(0).getUpperLeftPoint().getY()));
				d.getTxtVisina().setText(Integer.toString(dlm.get(0).getHeight()));
				d.getTxtSirina().setText(Integer.toString(dlm.get(0).getWidth()));
				d.setVisible(true);
				dlm.remove(0);
				
				
				} catch(ArrayIndexOutOfBoundsException ex) {
					JOptionPane.showMessageDialog(null, "Stack is empty!","Error", JOptionPane.WARNING_MESSAGE);
				}
			}
		});
		
		pnlW.add(btnDelete);
		
		JPanel pnlCentar = new JPanel();
		pnlCentar.setBackground(Color.LIGHT_GRAY);
		contentPane.add(pnlCentar, BorderLayout.CENTER);
		pnlCentar.setLayout(new BorderLayout(0, 0));
		
		JScrollPane scrollPane = new JScrollPane();
		pnlCentar.add(scrollPane);
		
		JList list = new JList();
		scrollPane.setViewportView(list);
		list.setModel(dlm);
	}
}

