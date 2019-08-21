package stackApp;

import java.awt.BorderLayout;
import java.awt.FlowLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JButton;
import javax.swing.JDialog;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JTextField;
import javax.swing.border.EmptyBorder;

import net.miginfocom.swing.MigLayout;
import java.awt.Dialog.ModalityType;
import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;
import java.awt.Font;
import java.awt.Color;

public class DlgAdd extends JDialog {

	private final JPanel pnlCenter = new JPanel();
	private boolean isOK;
	private boolean isUneseno;
	private JTextField txtX;
	private JTextField txtY;
	private JTextField txtHeight;
	private JTextField txtWidth;
	private JButton btnOk;
	private JButton btnAdd;
	private JButton btnQuit;
	
	public boolean isUneseno() {
		return isUneseno;
	}

	public void setUneseno(boolean isUneseno) {
		this.isUneseno = isUneseno;
	}
	
	public JButton getBtnOk() {
		return btnOk;
	}
	
	public JButton getBtnDodaj() {
		return btnAdd;
	}

	public JButton getBtnOdustani() {
		return btnQuit;
	}

	public JTextField getTxtX() {
		return txtX;
	}

	public void setTxtX(JTextField txtX) {
		this.txtX = txtX;
	}

	public JTextField getTxtY() {
		return txtY;
	}

	public void setTxtY(JTextField txtY) {
		this.txtY = txtY;
	}

	public JTextField getTxtVisina() {
		return txtHeight;
	}

	public void setTxtVisina(JTextField txtVisina) {
		this.txtHeight = txtVisina;
	}

	public JTextField getTxtSirina() {
		return txtWidth;
	}

	public void setTxtSirina(JTextField txtSirina) {
		this.txtWidth = txtSirina;
	}

	public JPanel getPnlGlavni() {
		return pnlCenter;
	}
	
	public JPanel getContentPanel() {
		return pnlCenter;
	}

	public void setOK(boolean isOK) {
		this.isOK = isOK;
	}

	public boolean isOK() {
		return isOK;
	}

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		try {
			DlgAdd dialog = new DlgAdd();
			dialog.setDefaultCloseOperation(JDialog.DISPOSE_ON_CLOSE);
			dialog.setVisible(true);
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	/**
	 * Create the dialog.
	 */
	public DlgAdd() {
		setModalityType(ModalityType.DOCUMENT_MODAL);
		setTitle("Add");
		setModal(true);
		setBounds(100, 100, 199, 314);
		getContentPane().setLayout(new BorderLayout());
		pnlCenter.setBackground(Color.LIGHT_GRAY);
		pnlCenter.setBorder(new EmptyBorder(5, 5, 5, 5));
		getContentPane().add(pnlCenter, BorderLayout.CENTER);
		pnlCenter.setLayout(new MigLayout("", "[66px][115px,grow]", "[50px][50][50][50]"));
		
		JLabel lblX = new JLabel("X:");
		pnlCenter.add(lblX, "cell 0 0,alignx left,aligny center");
		
		txtX = new JTextField();
		txtX.addKeyListener(new KeyAdapter() {
			@Override
			public void keyTyped(KeyEvent e) {
				char c = e.getKeyChar();
				if (!((c >= '0') && (c <= '9') ||
						(c == KeyEvent.VK_BACK_SPACE) ||
						(c == KeyEvent.VK_DELETE))) {
					e.consume();
					getToolkit().beep();
				}
			}
		});
		txtX.setColumns(10);
		pnlCenter.add(txtX, "cell 1 0,growx,aligny center");
		
		JLabel lblY = new JLabel("Y:");
		pnlCenter.add(lblY, "cell 0 1,alignx left,aligny center");
		
		txtY = new JTextField();
		txtY.addKeyListener(new KeyAdapter() {
			@Override
			public void keyTyped(KeyEvent e) {
				char c = e.getKeyChar();
				if (!((c >= '0') && (c <= '9') ||
						(c == KeyEvent.VK_BACK_SPACE) ||
						(c == KeyEvent.VK_DELETE))) {
					e.consume();
					getToolkit().beep();
				}
			}
		});
		txtY.setColumns(10);
		pnlCenter.add(txtY, "cell 1 1,growx,aligny center");
		
		JLabel lblHeight = new JLabel("Height:");
		pnlCenter.add(lblHeight, "cell 0 2,alignx left,aligny center");
		
		txtHeight = new JTextField();
		txtHeight.addKeyListener(new KeyAdapter() {
			@Override
			public void keyTyped(KeyEvent e) {
				char c = e.getKeyChar();
				if (!((c >= '0') && (c <= '9') ||
						(c == KeyEvent.VK_BACK_SPACE) ||
						(c == KeyEvent.VK_DELETE))) {
					e.consume();
					getToolkit().beep();
				}
			}
		});
		txtHeight.setColumns(10);
		pnlCenter.add(txtHeight, "cell 1 2,growx,aligny center");
		
		JLabel lblWidth = new JLabel("Width:");
		pnlCenter.add(lblWidth, "cell 0 3,alignx left,aligny center");
		
		txtWidth = new JTextField();
		txtWidth.addKeyListener(new KeyAdapter() {
			@Override
			public void keyTyped(KeyEvent e) {
				char c = e.getKeyChar();
				if (!((c >= '0') && (c <= '9') ||
						(c == KeyEvent.VK_BACK_SPACE) ||
						(c == KeyEvent.VK_DELETE))) {
					e.consume();
					getToolkit().beep();
				}
			}
		});
		txtWidth.setColumns(10);
		pnlCenter.add(txtWidth, "cell 1 3,growx,aligny center");
		
		{
			JPanel pnlBtn = new JPanel();
			pnlBtn.setBackground(Color.GRAY);
			pnlBtn.setLayout(new FlowLayout(FlowLayout.RIGHT));
			getContentPane().add(pnlBtn, BorderLayout.SOUTH);
			{
			    btnAdd = new JButton("Add");
				btnAdd.addActionListener(new ActionListener() {
					public void actionPerformed(ActionEvent e) {
						if(getTxtX().getText().isEmpty() || getTxtY().getText().isEmpty() || getTxtSirina().getText().isEmpty() || getTxtVisina().getText().isEmpty()) {
							isOK = false;
							setVisible(true);
							JOptionPane.showMessageDialog(null, "Morate popuniti sva polja!","Greska", JOptionPane.WARNING_MESSAGE);
						} else {
							isOK = true;
							dispose();
						}
					}
				});
				
			    btnOk = new JButton("OK");
			    btnOk.addActionListener(new ActionListener() {
			    	public void actionPerformed(ActionEvent e) {
			    		dispose();
			    	}
			    });
				btnOk.setVisible(false);
				pnlBtn.add(btnOk);
				btnAdd.setActionCommand("OK");
				pnlBtn.add(btnAdd);
				getRootPane().setDefaultButton(btnAdd);
			}
			{
				btnQuit = new JButton("Quit");
				btnQuit.setFont(new Font("Tahoma", Font.PLAIN, 13));
				btnQuit.addActionListener(new ActionListener() {
					public void actionPerformed(ActionEvent e) {
						isOK = false;
						txtX.setText("");
						txtY.setText("");
						txtWidth.setText("");
						txtHeight.setText("");
						dispose();
					}
				});
				btnQuit.setActionCommand("Cancel");
				pnlBtn.add(btnQuit);
			}
		}
	}
}
