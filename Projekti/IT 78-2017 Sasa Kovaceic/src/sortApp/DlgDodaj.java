package sortApp;

import java.awt.BorderLayout;
import java.awt.FlowLayout;

import javax.swing.JButton;
import javax.swing.JDialog;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JTextField;
import javax.swing.border.EmptyBorder;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;
import net.miginfocom.swing.MigLayout;
import java.awt.Dialog.ModalityType;
import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;

public class DlgDodaj extends JDialog {

	private final JPanel pnlGlavni = new JPanel();
	private boolean isOK;
	private JTextField txtX;
	private JTextField txtY;
	private JTextField txtVisina;
	private JTextField txtSirina;
	private JButton btnDodaj;
	private JButton btnOdustani;
		
	public JButton getBtnDodaj() {
		return btnDodaj;
	}

	public JButton getBtnOdustani() {
		return btnOdustani;
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
		return txtVisina;
	}

	public void setTxtVisina(JTextField txtVisina) {
		this.txtVisina = txtVisina;
	}

	public JTextField getTxtSirina() {
		return txtSirina;
	}

	public void setTxtSirina(JTextField txtSirina) {
		this.txtSirina = txtSirina;
	}

	public JPanel getPnlGlavni() {
		return pnlGlavni;
	}
	
	public JPanel getContentPanel() {
		return pnlGlavni;
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
			DlgDodaj dialog = new DlgDodaj();
			dialog.setDefaultCloseOperation(JDialog.DISPOSE_ON_CLOSE);
			dialog.setVisible(true);
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	/**
	 * Create the dialog.
	 */
	public DlgDodaj() {
		setModalityType(ModalityType.DOCUMENT_MODAL);
		setTitle("Dodavanje");
		setModal(true);
		setBounds(100, 100, 264, 300);
		getContentPane().setLayout(new BorderLayout());
		pnlGlavni.setBorder(new EmptyBorder(5, 5, 5, 5));
		getContentPane().add(pnlGlavni, BorderLayout.CENTER);
		pnlGlavni.setLayout(new MigLayout("", "[66px][115px,grow]", "[50px][50][50][50]"));
		
		JLabel lblX = new JLabel("X:");
		pnlGlavni.add(lblX, "cell 0 0,alignx left,aligny center");
		
		txtX = new JTextField();
		txtX.setTransferHandler(null); //da bismo zabranili pastovanje u textfield, da ne bi korisnik kopirao neki string
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
		pnlGlavni.add(txtX, "cell 1 0,growx,aligny center");
		
		JLabel lblY = new JLabel("Y:");
		pnlGlavni.add(lblY, "cell 0 1,alignx left,aligny center");
		
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
		pnlGlavni.add(txtY, "cell 1 1,growx,aligny center");
		
		JLabel lblVisina = new JLabel("Visina:");
		pnlGlavni.add(lblVisina, "cell 0 2,alignx left,aligny center");
		
		txtVisina = new JTextField();
		txtVisina.addKeyListener(new KeyAdapter() {
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
		txtVisina.setColumns(10);
		pnlGlavni.add(txtVisina, "cell 1 2,growx,aligny center");
		
		JLabel lblSirina = new JLabel("Sirina:");
		pnlGlavni.add(lblSirina, "cell 0 3,alignx left,aligny center");
		
		txtSirina = new JTextField();
		txtSirina.addKeyListener(new KeyAdapter() {
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
		txtSirina.setColumns(10);
		pnlGlavni.add(txtSirina, "cell 1 3,growx,aligny center");
		
		{
			JPanel pnlDugmici = new JPanel();
			pnlDugmici.setLayout(new FlowLayout(FlowLayout.RIGHT));
			getContentPane().add(pnlDugmici, BorderLayout.SOUTH);
			{
			    btnDodaj = new JButton("Dodaj");
				btnDodaj.addActionListener(new ActionListener() {
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
				btnDodaj.setActionCommand("OK");
				pnlDugmici.add(btnDodaj);
				getRootPane().setDefaultButton(btnDodaj);
			}
			{
				btnOdustani = new JButton("Odustani");
				btnOdustani.addActionListener(new ActionListener() {
					public void actionPerformed(ActionEvent e) {
						isOK = false;
						txtX.setText("");
						txtY.setText("");
						txtSirina.setText("");
						txtVisina.setText("");
						dispose();
					}
				});
				btnOdustani.setActionCommand("Cancel");
				pnlDugmici.add(btnOdustani);
			}
		}
	}
}
