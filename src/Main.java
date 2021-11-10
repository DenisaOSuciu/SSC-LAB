import java.math.BigInteger;

public class Main {
private static BigInteger NaiveSquareRoot(BigInteger a, BigInteger l, BigInteger r){
    BigInteger root=l.add(r).shiftRight(1);

    if(!((root.pow(3).compareTo(a)==-1)&&(root.add(BigInteger.ONE).pow(3).compareTo(a)==1))){
        if(root.pow(3).compareTo(a)==-1)
            root=NaiveSquareRoot(a,root,r);
        if(root.pow(3).compareTo(a)==1)
            root=NaiveSquareRoot(a,l,root);
    }


    return root;
}

public static BigInteger SquareRoot(BigInteger a){
    return NaiveSquareRoot(a, BigInteger.ZERO,a);
}


    public static void main(String[] args) {
    BigInteger n=new BigInteger("8716664131891073309298060436222387808362956786786341866937428783455365962391673917249574491595229207084297741464557132198229086365652604590297378403184129");
    BigInteger e=new BigInteger("3");
    BigInteger c=new BigInteger("1375865583010982618632308529423371271821438577980922927124130396877925863587827122886875024570556859122064458153631");

    BigInteger message =SquareRoot(c);

    System.out.println(message);
    }
}
