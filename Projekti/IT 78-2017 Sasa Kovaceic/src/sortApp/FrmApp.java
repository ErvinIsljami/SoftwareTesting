package sortApp;

import java.awt.BorderLayout;
import java.awt.EventQueue;
import java.awt.FlowLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.ArrayList;
import java.util.Iterator;

import javax.swing.DefaultListModel;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JList;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTextField;
import javax.swing.border.EmptyBorder;

public class FrmApp extends JFrame {

	private JPanel contentPane;
	private DefaultListModel<Rectangle> dlm = new DefaultListModel<Rectangle>();
	
	ArrayList<Rectangle> recList = new ArrayList<Rectangle>();
	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					FrmApp frame = new FrmApp();
					frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the frame.
	 */
	public FrmApp() {
		setTitle("Sort");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 450, 300);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		contentPane.setLayout(new BorderLayout(0, 0));
		setContentPane(contentPane);
		
		JPanel pnlSever = new JPanel();
		contentPane.add(pnlSever, BorderLayout.NORTH);
		
		JLabel lblRectangle = new JLabel("Rectangle Sort App");
		pnlSever.add(lblRectangle);
		
		JPanel pnlZapad = new JPanel();
		FlowLayout flowLayout = (FlowLayout) pnlZapad.getLayout();
		contentPane.add(pnlZapad, BorderLayout.WEST);
		
		JButton btnDodaj = new JButton("Dodaj");
		btnDodaj.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				DlgDodaj d = new DlgDodaj();
				d.setVisible(true);
				if(d.isOK()) {
					try {
							Point p = new Point(Integer.parseInt(d.getTxtX().getText()),Integer.parseInt(d.getTxtY().getText()));
							Rectangle r = new Rectangle(p,Integer.parseInt(d.getTxtVisina().getText()),Integer.parseInt(d.getTxtSirina().getText()));
							dlm.addElement(r);
							recList.add(r);
						}catch(NumberFormatException ex) {
							JOptionPane.showMessageDialog(null, "Unesite iskljucivo brojeve!","Greska", JOptionPane.WARNING_MESSAGE);
						}
				}
				d.getTxtX().setText("");
				d.getTxtY().setText("");
				d.getTxtSirina().setText("");
				d.getTxtVisina().setText("");
			}
		});
		pnlZapad.add(btnDodaj);
		
		JButton btnSortiraj = new JButton("Sortiraj");
		btnSortiraj.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if(recList.isEmpty()) {
					JOptionPane.showMessageDialog(null, "Lista je prazna!", "Greska", JOptionPane.WARNING_MESSAGE);
				}
				recList.sort(null);
				dlm.clear();
				for (int i = 0; i < recList.size(); i++)
				{
				    dlm.addElement(recList.get(i));
				}
			}
		});
		pnlZapad.add(btnSortiraj);
		
		JPanel pnlCentar = new JPanel();
		contentPane.add(pnlCentar, BorderLayout.CENTER);
		pnlCentar.setLayout(new BorderLayout(0, 0));
		
		JScrollPane scrollPane = new JScrollPane();
		pnlCentar.add(scrollPane);
		
		JList list = new JList();
		scrollPane.setViewportView(list);
		list.setModel(dlm);
	}
}

