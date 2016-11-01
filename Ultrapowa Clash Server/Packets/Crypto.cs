/*
 * Program : Ultrapowa Clash Server
 * Description : A C# Writted 'Clash of Clans' Server Emulator !
 *
 * Authors:  Jean-Baptiste Martin <Ultrapowa at Ultrapowa.com>,
 *           And the Official Ultrapowa Developement Team
 *
 * Copyright (c) 2016  UltraPowa
 * All Rights Reserved.
 */

using System;
using Sodium;

namespace UCS.PacketProcessing
{
    public static class Key
    {
        public static Crypto Crypto
        {
            get { return new Crypto((byte[]) _standardPublicKey.Clone(), (byte[]) _standardPrivateKey.Clone()); }
        }

        static readonly byte[] _standardPrivateKey =
        {
            0x18, 0x91, 0xD4, 0x01, 0xFA, 0xDB, 0x51, 0xD2, 0x5D, 0x3A, 0x91, 0x74,
            0xD4, 0x72, 0xA9, 0xF6, 0x91, 0xA4, 0x5B, 0x97, 0x42, 0x85, 0xD4, 0x77,
            0x29, 0xC4, 0x5C, 0x65, 0x38, 0x07, 0x0D, 0x85
        };

        static readonly byte[] _standardPublicKey =
        {
            0x72, 0xF1, 0xA4, 0xA4, 0xC4, 0x8E, 0x44, 0xDA, 0x0C, 0x42, 0x31, 0x0F,
            0x80, 0x0E, 0x96, 0x62, 0x4E, 0x6D, 0xC6, 0xA6, 0x41, 0xA9, 0xD4, 0x1C,
            0x3B, 0x50, 0x39, 0xD8, 0xDF, 0xAD, 0xC2, 0x7E
        };
    }

    public class Crypto : IDisposable
    {
        public Crypto(byte[] publicKey, byte[] privateKey)
        {
            if (publicKey == null)
                throw new ArgumentNullException(nameof(publicKey));
            if (publicKey.Length != PublicKeyBox.PublicKeyBytes)
                throw new ArgumentOutOfRangeException(nameof(publicKey), "publicKey must be 32 bytes in length.");

            if (privateKey == null)
                throw new ArgumentNullException(nameof(privateKey));
            if (privateKey.Length != PublicKeyBox.SecretKeyBytes)
                throw new ArgumentOutOfRangeException(nameof(privateKey), "publicKey must be 32 bytes in length.");

            _keyPair = new KeyPair(publicKey, privateKey);
        }

        public void Dispose()
        {
            if (_disposed)
                return;

            _keyPair.Dispose();
            _disposed = true;
            GC.SuppressFinalize(this);
        }

        public const int KeyLength = 32;
        public const int NonceLength = 24;
        readonly KeyPair _keyPair;
        bool _disposed;

        public byte[] PrivateKey
        {
            get
            {
                if (_disposed)
                    throw new ObjectDisposedException(null, "Cannot access CoCKeyPair object because it was disposed.");
                return _keyPair.PrivateKey;
            }
        }

        public byte[] PublicKey
        {
            get
            {
                if (_disposed)
                    throw new ObjectDisposedException(null, "Cannot access CoCKeyPair object because it was disposed.");
                return _keyPair.PublicKey;
            }
        }
    }
}
